using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class PumpController : Controller
    {
        private readonly PumpService _pumpService;
        public PumpController(PumpService pumpService)
        {
            _pumpService = pumpService;
        }
        public IActionResult Index()
        {
            var userId = Request.Cookies["admToken"];
            var data = _pumpService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PumpMaster pmp)
        {

            try
            {
                pmp.UsmId = Request.Cookies["admToken"];
                var data = _pumpService.Create(pmp);
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
            var data = _pumpService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, PumpMaster pmp)
        {

            try
            {
                var data = _pumpService.Update(id, pmp);
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
            var data = _pumpService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
