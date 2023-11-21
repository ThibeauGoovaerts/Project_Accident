using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using WebApplication4.Data;
using WebApplication4.Models;
using System.Composition;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebApplication4.Controllers
{
    [Authorize(Roles = "rh,responsable,contremaitre,employe")]
    public class AccidentsController : Controller
    {
        private readonly AccidentContext _context;
        private UserManager<User> _userManager;

        public AccidentsController(AccidentContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Accidents
        public async Task<IActionResult> Index()
        {
            var accidentContext = _context.Accidents.Include(a => a.Location);
            return View(await accidentContext.ToListAsync());
        }


        // GET: Accidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accidents == null)
            {
                return NotFound();
            }

            var accident = await _context.Accidents
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accident == null)
            {
                return NotFound();
            }

            return View(accident);
        }

        public async Task<IActionResult> CreateTestimony(int? id) {

            if (id == null || _context.Accidents == null) {
                return NotFound();
            }

            var accident = await _context.Accidents.FindAsync(id);
            if (accident == null) {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            Report report = new Report();
            report.Accident = _context.Accidents.FirstOrDefault(a => a.ID == id);
            report.Description = "";
            report.PersonID = user.PersonID;
            _context.Reports.Add(report);

            _context.SaveChanges();

            return RedirectToAction(nameof(EditTestimony), new { id = report.ID });
        }

        // GET: Accidents/EditTestimony/5
        public async Task<IActionResult> EditTestimony(int? id) {
            if (id == null || _context.Reports == null) {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(id);
            if (report == null) {
                return NotFound();
            }

            // Si le témoignage n'est pas éditer par la personne a qui il appartient.
            var user = await _userManager.GetUserAsync(User);
            if (report.PersonID != user.PersonID) {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTestimony(int id, string Testimony, bool WasPresent) {
            Report report = _context.Reports.SingleOrDefault(r => r.ID == id);

            if (id != report.ID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                report.isOpen = false;
                var user = await _userManager.GetUserAsync(User);
                SaveTestimony(report.AccidentID, WasPresent, Testimony, user);
				_context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "contremaitre")]
        // GET: Accidents/Create
        public async Task<IActionResult> CreateAsync()
        {

            var user = await _userManager.GetUserAsync(User);

            Accident tempAccident = new Accident();
            tempAccident.AccidentDateTime = DateTime.MinValue;
            tempAccident.Reaction = "";
            tempAccident.LocationDetail = "";
            tempAccident.Probability = -1;
            tempAccident.Gravity = -1;
            tempAccident.LocationID = _context.Locations.FirstOrDefault().ID;
            _context.Accidents.Add(tempAccident);

            VictimInformation vict = new VictimInformation();
            vict.AccidentID = tempAccident.ID;
            vict.Accident = tempAccident;
            _context.VictimInformations.Add(vict);

            tempAccident.VictimInformation = vict;

            Report report = new Report();
            report.Accident = tempAccident;
            report.Description = "";
            report.PersonID = user.PersonID; 
            _context.Reports.Add(report);

            _context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = tempAccident.ID });
        }

        // POST: Accidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AccidentDateTime,Reaction,LocationDetail,Probability,Gravity,LocationID")] Accident accident, List<string>FundamentaryCausesChecked, List<string> DirectMesuresChecked, String? textAreaMesure, String? mesureAppliqueeAutre, String? textAreaOrganisation, String? fundamentaryCausesOther, List<string> detailsAgentMat, List<string> detailsDeviations,List<string> ProposedMesuresDetailsChecked)
        {
            
            ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID", accident.LocationID);
            ViewBag.Locations = _context.Locations.ToList();
            ViewBag.FundamentaryCauses = _context.FundamentaryCauses.Where(f => f.IsDefault == true).ToList();
            ViewBag.DirectMesuresAll = _context.DirectMesures.Where(f => f.IsDefault == true).ToList();
            ViewBag.DirectMesuresAll = _context.DirectMesures.ToList();
            //------------------------------- Thibeau

            ViewData["categories"] = _context.MaterialAgents.ToList();

            ViewData["details"] = _context.MaterialAgentDetails.ToList();

            ViewData["startAtZeroOrNot"] = _context.MaterialAgentDetails.First().Code == 0;

            ViewData["categoriesDeviation"] = _context.Deviations.ToList();

            ViewData["detailsDeviation"] = _context.DeviationDetails.ToList();

            ViewData["startAtZeroOrNotDeviation"] = _context.DeviationDetails.First().Code == 0;

            //-------------------------------
            ViewData["ProposedMesuresCategorie"] = _context.ProposedMesures.ToList();
            ViewData["ProposedMesuresDetail"] = _context.ProposedMesureDetails.ToList();
            ViewData["startAtZeroOrNotProposedMesure"] = _context.ProposedMesureDetails.First().Code == 0;

            return View(accident);
        }

        // GET: Accidents/Edit/5
        [Authorize(Roles = "contremaitre")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accidents == null)
            {
                return NotFound();
            }

            var accident = await _context.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            // Si le rapport n'est pas éditer par la personne a qui il appartient.
            var user = await _userManager.GetUserAsync(User);
            Report report = _context.Reports.FirstOrDefault(r => r.AccidentID == accident.ID);
            if (report.PersonID != user.PersonID) {
                return RedirectToAction("Index","Home");
            }

            //Pour la vérification de la page vide
            accident.LocationID = 0;


            // Report_General.cshtml
            var personsListItems = new List<string>();
            var firmsList = new List<string>();

            foreach (var f in _context.OutsideFirms.ToList()) {
                firmsList.Add(f.Label);
            }

            foreach (var p in _context.Persons.ToList()) {
                personsListItems.Add(p.LastName + ":" + p.FirstName);
            }

            ViewData["personsList"] = JsonSerializer.Serialize(personsListItems);
            ViewData["firmsList"] = JsonSerializer.Serialize(firmsList);

            // Report_Protections.cshtml
            ViewBag.protections = _context.Protections.ToList();

            // Report_Lesions.cshtml
            ViewData["startAtZeroOrNotLesionSeat"] = _context.LesionSeatDetails.First().Code == 0;
            ViewData["startAtZeroOrNotLesionNature"] = _context.NatureLesionDetails.First().Code == 0;
            ViewData["lesionSeatsDetails"] = _context.LesionSeatDetails.ToList();
			ViewData["lesionNatureCategories"] = _context.NatureLesions.ToList();
			ViewData["lesionNatureDetails"] = _context.NatureLesionDetails.ToList();

			// Report_Location.cshtml
			ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID");
            ViewBag.Locations = _context.Locations.ToList();

            // Report_Deviation.cshtml
            ViewData["categoriesDeviation"] = _context.Deviations.ToList();
            ViewData["detailsDeviation"] = _context.DeviationDetails.ToList();
            ViewData["startAtZeroOrNotDeviation"] = _context.DeviationDetails.First().Code == 0;

            // Report_AgentMateriel.cshtml
            ViewData["categories"] = _context.MaterialAgents.ToList();
            ViewData["details"] = _context.MaterialAgentDetails.ToList();
            ViewData["startAtZeroOrNot"] = _context.MaterialAgentDetails.First().Code == 0;

            // Report_FundamentaryCause.cshtml
            ViewBag.FundamentaryCauses = _context.FundamentaryCauses.Where(f => f.IsDefault == true).ToList();

            // Report_Mesures.cshtml
            ViewBag.DirectMesuresAll = _context.DirectMesures.Where(f => f.IsDefault == true).ToList();
            ViewData["ProposedMesuresCategorie"] = _context.ProposedMesures.ToList();
            ViewData["ProposedMesuresDetail"] = _context.ProposedMesureDetails.ToList();
            ViewData["startAtZeroOrNotProposedMesure"] = _context.ProposedMesureDetails.First().Code == 0;

            return View(accident);
        }

        // POST: Accidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,DateTime AccidentDateTime, string Reaction, string LocationDetail, int Probability, int Gravity, int LocationID , List<string> FundamentaryCausesChecked, List<string> DirectMesuresChecked, String? textAreaMesure, String? mesureAppliqueeAutre, String? textAreaOrganisation, String? fundamentaryCausesOther, List<string> detailsAgentMat, List<string> detailsDeviations, List<string> ProposedMesuresDetailsChecked, List<string> protectionsVictim, string Lastname, string Firstname, string? ExternalFirmName, string? lesionResult, string Testimony,bool WorkStopped,DateTime? DateTimeWorkStopped,bool WorkResumed,DateTime? DateTimeWorkResumed,bool UsualFunction,string ActivityDuringAccident, List<string> LesionSeatDetailChecked, List<string> LesionNaturesDetailsChecked, bool isExternal, bool WasPresent)
        {
            Accident accident = _context.Accidents.SingleOrDefault(a => a.ID == id);

            if (id != accident.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid) {

                /* ACCIDENT */

                SaveAccident(accident.ID, AccidentDateTime, LocationID, LocationDetail);
                SaveReaction(accident.ID, Reaction);
                SaveProbability(accident.ID, Probability, Gravity);

                if (mesureAppliqueeAutre != "false" && textAreaMesure != null) {
                    DirectMesure directMesureText = new DirectMesure { Label = textAreaMesure, IsDefault = false };
                    _context.DirectMesures.Add(directMesureText);
                    accident.DirectMesures.Add(directMesureText);
                    _context.SaveChanges();
                }

                if (fundamentaryCausesOther != "false" && textAreaOrganisation != null) {
                    FundamentaryCause fundamentaryCause = new FundamentaryCause { Label = textAreaOrganisation, IsDefault = false };
                    _context.FundamentaryCauses.Add(fundamentaryCause);
                    accident.FundamentaryCauses.Add(fundamentaryCause);
                    _context.SaveChanges();
                }

                _context.Update(accident);
                await _context.SaveChangesAsync();

                /* VICTIME */

                SaveVictim(id, Lastname, Firstname, ExternalFirmName, isExternal);
                SaveVictimActivity(accident.ID, UsualFunction, ActivityDuringAccident);
                SaveVictimPause(accident.ID, WorkStopped, DateTimeWorkStopped, WorkResumed, DateTimeWorkResumed);
                var user = await _userManager.GetUserAsync(User);
                SaveTestimony(accident.ID, WasPresent, Testimony, user);

                Report report = _context.Reports.FirstOrDefault(m => m.AccidentID == accident.ID & m.PersonID==user.PersonID);
                report.isOpen = false;
                _context.Reports.Update(report);
                _context.SaveChanges();

                return RedirectToAction("Details", "Reports", new { id = report.ID });
            }

			// Report_General.cshtml
			var personsListItems = new List<string>();
			var firmsList = new List<string>();

			foreach (var f in _context.OutsideFirms.ToList()) {
				firmsList.Add(f.Label);
			}

			foreach (var p in _context.Persons.ToList()) {
				personsListItems.Add(p.LastName + " " + p.FirstName);
			}

			ViewData["personsList"] = JsonSerializer.Serialize(personsListItems);
			ViewData["firmsList"] = JsonSerializer.Serialize(firmsList);

			// Report_Protections.cshtml
			ViewBag.protections = _context.Protections.ToList();

            // Report_Lesions.cshtml
            ViewData["startAtZeroOrNotLesionSeat"] = _context.LesionSeatDetails.First().Code == 0;
            ViewData["startAtZeroOrNotLesionNature"] = _context.NatureLesionDetails.First().Code == 0;
            ViewData["lesionSeatsDetails"] = _context.LesionSeatDetails.ToList();
            ViewData["lesionNatureCategories"] = _context.NatureLesions.ToList();
            ViewData["lesionNatureDetails"] = _context.NatureLesionDetails.ToList();

            // Report_Location.cshtml
            ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID");
			ViewBag.Locations = _context.Locations.ToList();

			// Report_Deviation.cshtml
			ViewData["categoriesDeviation"] = _context.Deviations.ToList();
			ViewData["detailsDeviation"] = _context.DeviationDetails.ToList();
			ViewData["startAtZeroOrNotDeviation"] = _context.DeviationDetails.First().Code == 0;

			// Report_AgentMateriel.cshtml
			ViewData["categories"] = _context.MaterialAgents.ToList();
			ViewData["details"] = _context.MaterialAgentDetails.ToList();
			ViewData["startAtZeroOrNot"] = _context.MaterialAgentDetails.First().Code == 0;

			// Report_FundamentaryCause.cshtml
			ViewBag.FundamentaryCauses = _context.FundamentaryCauses.Where(f => f.IsDefault == true).ToList();

			// Report_Mesures.cshtml
			ViewBag.DirectMesuresAll = _context.DirectMesures.Where(f => f.IsDefault == true).ToList();
			ViewData["ProposedMesuresCategorie"] = _context.ProposedMesures.ToList();
			ViewData["ProposedMesuresDetail"] = _context.ProposedMesureDetails.ToList();
			ViewData["startAtZeroOrNotProposedMesure"] = _context.ProposedMesureDetails.First().Code == 0;

			return View(accident);
        }

        private bool AccidentExists(int id)
        {
          return _context.Accidents.Any(e => e.ID == id);
        }


        /* VICTIME IDENTITY */
        [Authorize(Roles = "contremaitre")]
        public string SaveVictim(int idAccident, string VictimLastname, string VictimFirstname, string ExternalFirmName, bool ExternalFirmChecked)
        {
            try {
                Accident accident = _context.Accidents.FirstOrDefault(m => m.ID == idAccident);
                VictimInformation vict = _context.VictimInformations.FirstOrDefault(v => v.AccidentID == idAccident);

                accident.VictimInformation = vict;

                if (accident == null)
                    return "Error";

                if (VictimLastname == null || VictimFirstname == null) {
                    return "Error";
                }

                if (ExternalFirmName != null && ExternalFirmChecked) {
                    OutsideFirm outsideFirm = _context.OutsideFirms.SingleOrDefault(o => o.Label.Equals(ExternalFirmName));
                    if (outsideFirm == null) {
                        outsideFirm = new OutsideFirm();
                        outsideFirm.Label = ExternalFirmName;
                        _context.Add(outsideFirm);
                        _context.SaveChanges();
                    }

                    Person personOutside = _context.Persons.SingleOrDefault(p => p.LastName.ToLower().Equals(VictimLastname.ToLower()) && p.FirstName.ToLower().Equals(VictimFirstname.ToLower()) && p.OutsideFirm.ID == outsideFirm.ID);
                    if (personOutside == null) {
                        personOutside = new Person();
                        personOutside.LastName = VictimLastname;
                        personOutside.FirstName = VictimLastname;
                        personOutside.OutsideFirmID = outsideFirm.ID;
                        _context.Add(personOutside);
                        _context.SaveChanges();
                        accident.VictimInformation.PersonID = personOutside.ID;
                    }
                } else {
                    Person person = _context.Persons.SingleOrDefault(p => p.LastName.ToLower().Equals(VictimLastname.ToLower()) && p.FirstName.ToLower().Equals(VictimFirstname.ToLower()) && p.OutsideFirm == null);
                    if(person == null) {
                        return "Error";
                    }
                    accident.VictimInformation.PersonID = person.ID;
                }

                _context.Update(accident);
                _context.SaveChanges();

                return "Success";
            } catch (Exception ex ) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveVictimAjax(int idAccident, string VictimLastname, string VictimFirstname, string ExternalFirmName, bool ExternalFirmChecked)
        {
            return Json(SaveVictim(idAccident, VictimLastname, VictimFirstname, ExternalFirmName, ExternalFirmChecked));
        }

        /* ACCIDENT GENERAL INFORMATIONS */
        [Authorize(Roles = "contremaitre")]
        public string SaveAccident(int idAccident, DateTime accidentDateTime, int lieuID, string detailLieu) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.AccidentDateTime = accidentDateTime;
                accident.LocationID = lieuID;
                accident.LocationDetail = detailLieu;
                _context.Update(accident);
                _context.SaveChanges();
                return "Success";
            } catch(Exception ex) {
                return "Error";
            }

        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAccidentAjax(int idAccident, DateTime accidentDateTime, int lieuID, string detailLieu) {
            return Json(SaveAccident(idAccident, accidentDateTime, lieuID, detailLieu));
        }

        /* TESTIMONY */

        public string SaveTestimony(int idAccident, bool wasPresent, string testimony, User user) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                Report report = _context.Reports.SingleOrDefault(m => m.AccidentID == accident.ID && m.PersonID==user.PersonID);

                report.DateTimeCreation = DateTime.Now;
                report.Description = testimony;
                report.WasPresent = wasPresent;

                _context.Update(report);
                _context.SaveChanges();

                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        public string SaveTestimonyIdReport(int idReport, bool wasPresent, string testimony)
        {
            try
            {
                Report report = _context.Reports.SingleOrDefault(m => m.ID == idReport);

                report.DateTimeCreation = DateTime.Now;
                report.Description = testimony;
                report.WasPresent = wasPresent;

                _context.Update(report);
                _context.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTestimonyAjax(int idAccident, bool wasPresent, string testimony) {
            var user = await _userManager.GetUserAsync(User);
            return Json(SaveTestimony(idAccident, wasPresent, testimony, user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTestimonyAjaxWithTestimony(int idReport, bool wasPresent, string testimony)
        {
            return Json(SaveTestimonyIdReport(idReport, wasPresent, testimony));
        }

        /* REACTION */

        [Authorize(Roles = "contremaitre")]
        public string SaveReaction(int idAccident, string reaction) {
            try {
            Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.Reaction = reaction;
                _context.Update(accident);
                _context.SaveChanges();

                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveReactionAjax(int idAccident, string reaction) {
            return Json(SaveReaction(idAccident, reaction));
        }

        /* VICTIM USUAL FONCTION */
        [Authorize(Roles = "contremaitre")]
        public string SaveVictimActivity(int idAccident, bool usualActivity, string activity) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                VictimInformation vict = _context.VictimInformations.FirstOrDefault(v => v.AccidentID == idAccident);

                vict.UsualFunction = usualActivity;
                vict.ActivityDuringAccident = activity;

                _context.Update(vict);
                _context.SaveChanges();

                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveVictimActivityAjax(int idAccident, bool usualActivity, string activity) {
            return Json(SaveVictimActivity(idAccident,usualActivity,activity));
        }

        /* VICTIM WORK STOP */
        [Authorize(Roles = "contremaitre")]
        public string SaveVictimPause(int idAccident, bool workPaused, DateTime? workPausedDT, bool workResumed, DateTime? workResumedDT) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                VictimInformation vict = _context.VictimInformations.FirstOrDefault(v => v.AccidentID == idAccident);

                if (workPaused) {
                    vict.WorkStopped = true;
                    vict.DateTimeWorkStopped = workPausedDT;
                    if (workResumed) {
                        vict.WorkResumed = true;
                        vict.DateTimeWorkResumed = workResumedDT;
                    } else {
                        vict.DateTimeWorkResumed = null;
                    }
                } else {
                    vict.DateTimeWorkStopped = null;
                    vict.DateTimeWorkResumed = null;
                }

                _context.Update(vict);
                _context.SaveChanges();

                return "Success";
            } catch (Exception ex) {
                return "Error";
            }

        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveVictimPauseAjax(int idAccident, bool workPaused, DateTime? workPausedDT, bool workResumed, DateTime? workResumedDT) {
            return Json(SaveVictimPause(idAccident, workPaused,workPausedDT,workResumed,workResumedDT));
        }

        /* LESION */
        /* VICTIM'S PROTECTIONS */
        [Authorize(Roles = "contremaitre")]
        public string SaveVictimProtections(int idAccident, string[] protectionsVictim) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                VictimInformation vict = _context.VictimInformations.FirstOrDefault(v => v.AccidentID == idAccident);
                vict.VictimProtectionAssets = new List<VictimProtectionAsset>();
                _context.Update(vict);

                foreach (string s in protectionsVictim) {
                    int protectionID = _context.Protections.Where(p => p.Label == s).FirstOrDefault().ID;
                    VictimProtectionAsset prot = new VictimProtectionAsset { ProtectionID = protectionID, VictimInformationID = vict.ID};
                    _context.VictimProtectionAssets.Add(prot);
                }

                _context.SaveChanges();
                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveVictimProtectionsAjax(int idAccident, string[] protectionsVictim) {
            return Json(SaveVictimProtections(idAccident, protectionsVictim));
        }

        [Authorize(Roles = "contremaitre")]
        public string SaveLesionNatures(int idAccident, string[] natures)
        {
            try
            {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                VictimInformation vict = _context.VictimInformations.FirstOrDefault(v => v.AccidentID == idAccident);
                vict.NatureLesionDetails = new HashSet<NatureLesionDetail>();

                foreach (string labelNature in natures)
                {
                    NatureLesionDetail d = _context.NatureLesionDetails.Where(m => m.Label == labelNature).FirstOrDefault();
                    vict.NatureLesionDetails.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveLesionNaturesAjax(int idAccident, string[] natures)
        {
            return Json(SaveLesionNatures(idAccident, natures));
        }

        [Authorize(Roles = "contremaitre")]
        public string SaveLesionSeats(int idAccident, string[] seats)
        {
            try
            {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                VictimInformation vict = _context.VictimInformations.FirstOrDefault(v => v.AccidentID == idAccident);
                vict.LesionSeatDetails = new HashSet<LesionSeatDetail>();

                foreach (string labelSeat in seats)
                {
                    LesionSeatDetail d = _context.LesionSeatDetails.Where(m => m.Label == labelSeat).FirstOrDefault();
                    vict.LesionSeatDetails.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveLesionSeatAjax(int idAccident, string[] seats)
        {
            return Json(SaveLesionSeats(idAccident, seats));
        }

        /* DEVIATIONS */
        [Authorize(Roles = "contremaitre")]
        public string SaveDeviations(int idAccident, string[] deviations) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.DeviationDetails = new HashSet<DeviationDetail>();

                foreach (string labelDeviation in deviations) {
                    DeviationDetail d = _context.DeviationDetails.Where(m => m.Label == labelDeviation).FirstOrDefault();
                    accident.DeviationDetails.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDeviationsAjax(int idAccident, string[] deviations) {
            return Json(SaveDeviations(idAccident, deviations));
        }

        /* AGENT MATERIEL */
        [Authorize(Roles = "contremaitre")]
        public string SaveAgentMateriel(int idAccident, string[] agentMateriels) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.MaterialAgentDetails = new HashSet<MaterialAgentDetail>();

                foreach (string labelAgent in agentMateriels) {
                    MaterialAgentDetail d = _context.MaterialAgentDetails.Where(m => m.Label == labelAgent).FirstOrDefault();
                    accident.MaterialAgentDetails.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAgentMaterielAjax(int idAccident, string[] agentMateriels) {
            return Json(SaveAgentMateriel(idAccident, agentMateriels));
        }

        /* CAUSES */
        [Authorize(Roles = "contremaitre")]
        public string SaveCauses(int idAccident, string[] causes) {
            try {

                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.FundamentaryCauses = new HashSet<FundamentaryCause>();

                foreach (string labelCause in causes) {
                    FundamentaryCause d = _context.FundamentaryCauses.Where(m => m.Label == labelCause).FirstOrDefault();
                    accident.FundamentaryCauses.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCausesAjax(int idAccident, string[] causes) {
            return Json(SaveCauses(idAccident, causes));
        }

        /* DIRECT MESURES */
        [Authorize(Roles = "contremaitre")]
        public string SaveDirectMesures(int idAccident, string[] directMesures) {
            try {

                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.DirectMesures = new HashSet<DirectMesure>();

                foreach (string labelMesure in directMesures) {
                    DirectMesure d = _context.DirectMesures.Where(m => m.Label == labelMesure).FirstOrDefault();
                    accident.DirectMesures.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDirectMesuresAjax(int idAccident, string[] directMesures) {
            return Json(SaveDirectMesures(idAccident, directMesures));
        }

        /* PROPOSED MESURES */
        [Authorize(Roles = "contremaitre")]
        public string SaveProposedMesures(int idAccident, string[] proposedMesures) {
            try {

                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.ProposedMesureDetails = new HashSet<ProposedMesureDetail>();

                foreach (string labelMesure in proposedMesures) {
                    ProposedMesureDetail d = _context.ProposedMesureDetails.Where(m => m.Label == labelMesure).FirstOrDefault();
                    accident.ProposedMesureDetails.Add(d);
                }
                _context.SaveChanges();
                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProposedMesuresAjax(int idAccident, string[] proposedMesures) {
            return Json(SaveProposedMesures(idAccident, proposedMesures));
        }

        /* PROBABILITY */
        [Authorize(Roles = "contremaitre")]
        public string SaveProbability(int idAccident, int probability ,int gravity) {
            try {
                Accident accident = _context.Accidents.SingleOrDefault(m => m.ID == idAccident);
                accident.Probability = probability;
                accident.Gravity = gravity;
                _context.Update(accident);
                _context.SaveChanges();

                return "Success";
            } catch (Exception ex) {
                return "Error";
            }
        }

        [Authorize(Roles = "contremaitre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProbabilityAjax(int idAccident, int probability, int gravity) {
            return Json(SaveProbability(idAccident, probability,gravity));
        }

    }
}
