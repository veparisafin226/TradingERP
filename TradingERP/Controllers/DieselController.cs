using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class DieselController : Controller
    {
        private readonly DieselService _dieselService;
        private readonly PumpService _pumpService;
        public DieselController(DieselService dieselService,PumpService pumpService)
        {
            _dieselService = dieselService;
            _pumpService = pumpService;
        }
        public IActionResult Index()
        {
            var userId = Request.Cookies["admToken"];
            var data = _dieselService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            return View();
        }

        [HttpPost]
        public IActionResult Create(DieselMaster dsm)
        {
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
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
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            var data = _dieselService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, DieselMaster dsm)
        {
            var userId = Request.Cookies["admToken"];
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
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
            var data = _dieselService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
