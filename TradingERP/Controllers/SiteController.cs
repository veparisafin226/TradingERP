using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class SiteController : Controller
    {
        private readonly SiteService _siteService;
        public SiteController(SiteService siteService)
        {
            _siteService = siteService;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var data = _siteService.ListByUser(userId);
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
        public IActionResult Create(SiteMaster stm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                stm.UsmId = Request.Cookies["admToken"];
                var data = _siteService.Create(stm);
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
            var data = _siteService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, SiteMaster stm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var data = _siteService.Update(id, stm);
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
            var data = _siteService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
