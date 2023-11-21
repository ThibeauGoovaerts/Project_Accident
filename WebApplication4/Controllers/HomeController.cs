using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;
using WebApplication4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;


namespace WebApplication4.Controllers {

    [Authorize(Roles = "rh,responsable,contremaitre,employe")]
    public class HomeController : Controller {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly AccidentContext _context;
        private UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, AccidentContext context, UserManager<User> userManager, SignInManager<User> signInManager) {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Roles = "rh,responsable,contremaitre,employe")]
        public IActionResult Index() {
            return RedirectToAction("ReportsList");
        }

        public async Task<IActionResult> ReportsListAsync() {

            try {
                var user = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("responsable") || roles.Contains("rh")) {
                    ViewData["role"] = 3;
                } else {
                    if (roles.Contains("contremaitre")) {
                        ViewData["role"] = 2;
                    } else {
                        ViewData["role"] = 1;
                    }
                }

                List<Report> opened = _context.Reports
                    .Include(r => r.Person)
                    .Include(r => r.Accident)
                    .ThenInclude(a => a.VictimInformation)
                    .ThenInclude(v => v.Person)
                    .ThenInclude(p => p.OutsideFirm)
                    .Where(r => r.PersonID == user.PersonID && r.isOpen == true).ToList();

                List<Report> closed = new List<Report>();
                if (roles.Contains("rh") || roles.Contains("responsable")) {

                    List<Accident> accidents = _context.Accidents.ToList();
                    foreach (var accident in accidents) {
                        Report temp = _context.Reports.OrderBy(r => r.ID).FirstOrDefault(r => r.AccidentID == accident.ID && r.isOpen == false);
                        if (temp != null) {
                            closed.Add(temp);
                        }
                    }

                } else {
                    closed = _context.Reports
                        .Include(r => r.Person)
                        .Include(r => r.Accident)
                        .ThenInclude(a => a.VictimInformation)
                        .ThenInclude(v => v.Person)
                        .ThenInclude(p => p.OutsideFirm)
                        .Where(r => r.PersonID == user.PersonID && r.isOpen == false).ToList();
                }

                List<Accident> accidentListOpened = _context.Accidents.Where(a => a.isOpenToTestimony == true).ToList();
                List<Report> alreadyReported = _context.Reports.Where(r => r.PersonID == user.PersonID).ToList();
                
                foreach(Report r in alreadyReported) {
                    if (accidentListOpened.Contains(r.Accident)) {
                        accidentListOpened.Remove(r.Accident);
                    }
                }

                List<Report> canTestimony = new List<Report>();
                foreach(Accident a in accidentListOpened) {
                    canTestimony.Add(_context.Reports.OrderBy(r => r.ID).First(r => r.AccidentID == a.ID));
                }

                List<Report> canTestimonyComplete = new List<Report>(); 
                foreach(Report report in canTestimony) {

                    var reported = _context.Reports
                        .Include(r => r.Person)
                        .Include(r => r.Accident)
                        .ThenInclude(a => a.VictimInformation)
                        .ThenInclude(v => v.Person)
                        .ThenInclude(p => p.OutsideFirm)
                        .Where(r => r.ID == report.ID).ToList();

                    canTestimonyComplete.Add(reported.First());
                    }

                ViewBag.openedAccident = opened;
                ViewBag.closedAccident = closed;
                ViewBag.canTestimony = canTestimonyComplete;
                return View();

            } catch (Exception ex) {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                return RedirectToAction("Index");
            }
        }

        public IActionResult CreateTestimony(int? id) {
            if(id == null) {
                return NotFound();
            }
            return RedirectToAction("CreateTestimony", "Accidents", new { id = id});
        }

        public IActionResult DetailsReport(int? id) {
            if(id == null) {
                return NotFound();
            }
            return RedirectToAction("Details", "Reports", new { id = id});
        }

        public async Task<IActionResult> EditReportAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            if(roles.Contains("contremaitre")) {
                var report =_context.Reports.Single(r => r.ID== id);
                return RedirectToAction("Edit", "Accidents", new { id = report.AccidentID });
            } else {
                return RedirectToAction("EditTestimony", "Accidents", new { id = id });
            }
        }

        public IActionResult CreateReport() {
            return RedirectToAction("Create", "Accidents");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}