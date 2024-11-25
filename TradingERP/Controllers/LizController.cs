using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class LizController : Controller
    {
        private readonly LizService _lizService;
        public LizController(LizService lizService)
        {
            _lizService = lizService;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var data = _lizService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(LizMaster lzm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                lzm.UsmId = Request.Cookies["admToken"];
                var data = _lizService.Create(lzm);
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
            var data = _lizService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, LizMaster lzm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var data = _lizService.Update(id, lzm);
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
            var data = _lizService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
