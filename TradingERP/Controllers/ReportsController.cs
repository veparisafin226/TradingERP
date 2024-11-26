﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult RGPartyWise(ReportFilter rf)
        {
            try
            {

                return Json(rf);
                var userId = Request.Cookies["admToken"];
                var userInfo = _userService.GetById(userId);
                ViewData["userData"] = userInfo;
                ViewData["partyList"] = _partyService.ActiveListByUser(userId);
                ViewBag.party = rf.party;
                ViewBag.fDate = rf.fromDate;
                ViewBag.tDate = rf.toDate;
                var fd = Convert.ToDateTime(rf.fromDate).ToString("dd-MM-yyyy");
                var td = Convert.ToDateTime(rf.toDate).ToString("dd-MM-yyyy");
                var data = _reportService.RgReportByParty(userId, rf.party, rf.fromDate, rf.toDate);
                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("RGPartyWise");
            }
        }
    }
}
