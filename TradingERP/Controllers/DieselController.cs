using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class DieselController : Controller
    {
        private readonly DieselService _dieselService;
        private readonly PumpService _pumpService;
        private readonly DriverService _driverService;
        public DieselController(DieselService dieselService,PumpService pumpService, DriverService driverService)
        {
            _dieselService = dieselService;
            _pumpService = pumpService;
            _driverService = driverService;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var data = _dieselService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["driverList"]=_driverService.ActiveListByUser(userId);
            return View();
        }

        [HttpPost]
        public IActionResult Create(DieselMaster dsm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            try
            {
                dsm.UsmId = Request.Cookies["admToken"];
                var data = _dieselService.Create(dsm);
                if (data == "Success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.response = data;
                }
            }
            catch (Exception ex)
            {
                ViewBag.response = "Error Occurred";
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            var data = _dieselService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, DieselMaster dsm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            try
            {
                var data = _dieselService.Update(id, dsm);
                if (data == "Success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.response = data;
                }
            }
            catch (Exception ex)
            {
                ViewBag.response = "Error Occurred";
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var data = _dieselService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
