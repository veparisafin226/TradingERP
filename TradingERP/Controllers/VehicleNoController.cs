using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class VehicleNoController : Controller
    {
        private readonly VehicleNoService _vehicleNoService;
        public VehicleNoController(VehicleNoService vehicleNoService)
        {
            _vehicleNoService = vehicleNoService;
        }
        public IActionResult Index()
        {
            var userId = Request.Cookies["admToken"];
            var data = _vehicleNoService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleNoMaster vnm)
        {

            try
            {
                vnm.UsmId = Request.Cookies["admToken"];
                var data = _vehicleNoService.Create(vnm);
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
            var data = _vehicleNoService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, VehicleNoMaster vnm)
        {

            try
            {
                var data = _vehicleNoService.Update(id, vnm);
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
            var data = _vehicleNoService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
