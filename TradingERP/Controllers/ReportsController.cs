using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class ReportsController : Controller
    {
        private readonly PartyService _partyService;
        private readonly ReportService _reportService;
        private readonly UserService _userService;
        private readonly VehicleNoService _vehicleNoService;
        public ReportsController(PartyService partyService, ReportService reportService, UserService userService, VehicleNoService vehicleNoService)
        {
            _partyService = partyService;
            _reportService = reportService;
            _userService = userService;
            _vehicleNoService = vehicleNoService;
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
        public IActionResult RGPartyWise(ReportFilter rf)
        {
            try
            {
                
                var userId = Request.Cookies["admToken"];
                var userInfo = _userService.GetById(userId);
                ViewData["userData"] = userInfo;
                ViewData["partyList"] = _partyService.ActiveListByUser(userId);
                ViewBag.party = rf.party;
                ViewBag.month = rf.month; 
                ViewBag.year=rf.year;
                var data = _reportService.RgReportByParty(userId,rf.party,rf.month,rf.year);
                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("RGPartyWise");
            }
        }

        public IActionResult VRPartyWise()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var userInfo = _userService.GetById(userId);
            ViewData["userData"] = userInfo;
            ViewData["vehicleNoList"] = _vehicleNoService.ActiveListByUser(userId);
            return View();
        }

        [HttpPost]
        public IActionResult VRPartyWise(ReportFilter rf)
        {
            try
            {

                var userId = Request.Cookies["admToken"];
                var userInfo = _userService.GetById(userId);
                ViewData["userData"] = userInfo;
                ViewData["vehicleNoList"] = _vehicleNoService.ActiveListByUser(userId);
                ViewBag.vNo = rf.party;
                ViewBag.month = rf.month;
                ViewBag.year = rf.year;
                var data = _reportService.vehicleReportByParty(userId, rf.party, rf.month, rf.year);
                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("VRPartyWise");
            }
        }
    }
}
