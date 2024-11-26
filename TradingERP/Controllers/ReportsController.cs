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
        public IActionResult RGPartyWise(string party,DateTime fromDate,DateTime toDate)
        {
            try
            {


                var userId = Request.Cookies["admToken"];
                var userInfo = _userService.GetById(userId);
                ViewData["userData"] = userInfo;
                ViewData["partyList"] = _partyService.ActiveListByUser(userId);
                ViewBag.party = party;
                if (fromDate.ToString("dd-MM-yyyy") != "01-01-0001")
                {
                    ViewBag.fromDate = fromDate.ToString("dd-MM-yyyy");
                }
                if (toDate.ToString("dd-MM-yyyy") != "01-01-0001")
                {
                    ViewBag.toDate = toDate.ToString("dd-MM-yyyy");
                }

                var data = _reportService.RgReportByParty(userId, party, fromDate.ToString("dd-MM-yyyy"), toDate.ToString("dd-MM-yyyy"));
                return View(data);
            }
            catch (Exception ex)
            {
                return Json(ex.Message+" => "+fromDate+" => "+toDate);
            }
        }
    }
}
