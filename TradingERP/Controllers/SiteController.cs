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
            var userId = Request.Cookies["admToken"];
            var data = _siteService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SiteMaster stm)
        {

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
            var data = _siteService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, SiteMaster stm)
        {

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
            var data = _siteService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
