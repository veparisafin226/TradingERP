using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class DriverController : Controller
    {
        private readonly DriverService _driverService;
        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }
        public IActionResult Index()
        {
            var userId = Request.Cookies["admToken"];
            var data = _driverService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DriverMaster drm)
        {
            
            try
            {
                drm.UsmId = Request.Cookies["admToken"];
                var data = _driverService.Create(drm);
                if (data == "Success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.response= data;
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
            var data = _driverService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id,DriverMaster drm)
        {

            try
            {
                var data = _driverService.Update(id,drm);
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
            var data = _driverService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
