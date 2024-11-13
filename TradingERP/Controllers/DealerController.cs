using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class DealerController : Controller
    {
        private readonly DealerService _dealerService;
        public DealerController(DealerService dealerService)
        {
            _dealerService = dealerService;
        }
        public IActionResult Index()
        {
            var userId = Request.Cookies["admToken"];
            var data = _dealerService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DealerMaster dlr)
        {

            try
            {
                dlr.UsmId = Request.Cookies["admToken"];
                var data = _dealerService.Create(dlr);
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
            var data = _dealerService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, DealerMaster dlr)
        {

            try
            {
                var data = _dealerService.Update(id, dlr);
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
            var data = _dealerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
