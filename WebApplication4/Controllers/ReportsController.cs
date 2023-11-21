using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Authorize(Roles = "rh,responsable,contremaitre,employe")]
    public class ReportsController : Controller
    {
        private readonly AccidentContext _context;
        private UserManager<User> _userManager;

        public ReportsController(AccidentContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }      

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reports == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            if(user == null) {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            if(roles.Contains("responsable") || roles.Contains("rh")) {
                ViewData["role"] = 3;
            } else {
                if (roles.Contains("contremaitre")) {
                    ViewData["role"] = 2;
                } else {
                    ViewData["role"] = 1;
                }
            }



            var report = await _context.Reports
                .Include(r => r.Person)
                .Include(r => r.Accident)
                .ThenInclude(a => a.VictimInformation)
                .ThenInclude(v => v.Person)
                .ThenInclude(p => p.OutsideFirm)
                .Include(r => r.Accident)
                .ThenInclude(a => a.Location)
                .Include(p => p.Person)
                .ThenInclude(p => p.user)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (report == null)
            {
                return NotFound();
            }

            var author = report.Person.user;
            var rolesAuthor = await _userManager.GetRolesAsync(author);

            if (rolesAuthor.Contains("responsable") || rolesAuthor.Contains("rh")) {
                ViewData["roleAuthor"] = 3;
            } else {
                if (rolesAuthor.Contains("contremaitre")) {
                    ViewData["roleAuthor"] = 2;
                } else {
                    ViewData["roleAuthor"] = 1;
                }
            }


            if ((int)ViewData["role"] >= 2) {

                if ((int)ViewData["role"] > 2) {
                    List<Report> testimonies = _context.Reports
                    .Include(r => r.Person)
                    .Where(r => r.AccidentID == report.AccidentID && r.isOpen == false)
                    .ToList();
                    ViewData["testimonies"] = testimonies;
                }

                var accident = await _context.Accidents
                    .Include(a => a.DeviationDetails)
                    .Include(a => a.MaterialAgentDetails)
                    .Include(a => a.ProposedMesureDetails)
                    .Include(a => a.FundamentaryCauses)
                    .Include(a => a.DirectMesures)
                    .FirstOrDefaultAsync(a => a.ID == report.AccidentID);

                var victim = await _context.VictimInformations
                    .Include(v => v.LesionSeatDetails)
                    .Include(v => v.NatureLesionDetails)
                    .FirstOrDefaultAsync(v => v.AccidentID == report.AccidentID);

                var lesionSeats = new List<string>();
                var lesionNature = new List<string>();

                foreach (var el in victim.NatureLesionDetails) {
                    lesionNature.Add(el.Label);
                }

                foreach (var el in victim.LesionSeatDetails) {
                    lesionSeats.Add(el.Label);
                }

                ViewData["lesionNature"] = lesionNature;
                ViewData["lesionSeat"] = lesionSeats;
                ViewData["accident"] = accident;
            }

            return View(report);
        }

        // GET: Reports/Create
        //victimID et dateAccident pour le passer au Create(post) et rechercher l'AccidentID
        public IActionResult Create(int? victimID, DateTime? dateAccident)
        {
            ViewData["VictimID"] = victimID;
            ViewData["DateAccident"] = dateAccident; 
            ViewData["AccidentID"] = new SelectList(_context.Accidents, "ID", "LocationDetail");
            ViewData["PersonID"] = new SelectList(_context.Persons, "ID", "ID");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //VictimID et DateAccident mis pour pouvoir rechercher l'AccidentID plus tard
        public async Task<IActionResult> Create(string Description, int VictimeID, DateTime DateAccident)
        {
            Report report = new Report();
            if (!String.IsNullOrEmpty(Description))
            {
                report.DateTimeCreation = DateTime.Now;
                report.Description = Description;

                // TODO : Rechercher l'accident pour les témoignages
                VictimInformation victim = _context.VictimInformations.SingleOrDefault(v => v.ID == VictimeID);
                Accident accident = _context.Accidents.SingleOrDefault(a => a.ID == victim.AccidentID);

                if(accident == null) {
                    return NotFound();
                }

                report.AccidentID = accident.ID;

                // TODO : Récuprer la session 
                report.PersonID = 5;


                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Reports", new { report.ID });
            }
            ViewData["AccidentID"] = new SelectList(_context.Accidents, "ID", "LocationDetail", report.AccidentID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "ID", "ID", report.PersonID);
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Reports == null) {
                return NotFound();
            } else {
                Report report =_context.Reports.FirstOrDefault(r => r.ID== id);
                return RedirectToAction("Edit", "Accidents", new { id = report.AccidentID });
            }
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateTimeCreation,Description,AccidentID,PersonID")] Report report)
        {
            if (id != report.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccidentID"] = new SelectList(_context.Accidents, "ID", "LocationDetail", report.AccidentID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "ID", "ID", report.PersonID);
            return View(report);
        }

        private bool ReportExists(int id)
        {
          return _context.Reports.Any(e => e.ID == id);
        }
    }
}
