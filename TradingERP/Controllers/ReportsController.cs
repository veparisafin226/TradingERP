using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class ReportsController : Controller
    {
        private readonly PartyService _partyService;
        private readonly ReportService _reportService;
        private readonly UserService _userService;
        public ReportsController(PartyService partyService, ReportService reportService, UserService userService)
        {
            _partyService = partyService;
            _reportService = reportService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RGPartyWise()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var userInfo = _userService.GetById(userId);
            ViewData["userData"] = userInfo;
            ViewData["partyList"] = _partyService.ActiveListByUser(userId);
            return View();
        }

        [HttpPost]
        public IActionResult RGPartyWise(string party,string fromDate,string toDate)
        {
            try
            {
                
                if (Request.Cookies["admToken"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                DateTime fDate,tDate;
                if (DateTime.TryParseExact(fromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate))
                {
                    // Successfully parsed the date
                    Console.WriteLine(fDate.ToString());
                }
                if (DateTime.TryParseExact(toDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate))
                {
                    // Successfully parsed the date
                    Console.WriteLine(tDate.ToString());
                }
                var userId = Request.Cookies["admToken"];
                var userInfo = _userService.GetById(userId);
                ViewData["userData"] = userInfo;
                ViewData["partyList"] = _partyService.ActiveListByUser(userId);
                ViewBag.party = party;
                if (fromDate != null)
                {
                    ViewBag.fromDate = fDate.ToString("dd-MM-yyyy");
                }
                if (toDate != null)
                {
                    ViewBag.toDate = Convert.ToDateTime(toDate).ToString("dd-MM-yyyy");
                }

                var data = _reportService.RgReportByParty(userId, party, fDate.ToString("dd-MM-yyyy"), tDate.ToString("dd-MM-yyyy"));
                return View(data);
            }
            catch (Exception ex)
            {
                return Json(ex.Message+" => "+fromDate+" => "+toDate);
            }
        }
    }
}
