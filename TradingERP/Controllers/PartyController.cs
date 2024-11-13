using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class PartyController : Controller
    {
        private readonly PartyService _partyService;
        public PartyController(PartyService partyService)
        {
            _partyService = partyService;
        }
        public IActionResult Index()
        {
            var userId = Request.Cookies["admToken"];
            var data = _partyService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PartyMaster prt)
        {

            try
            {
                prt.UsmId = Request.Cookies["admToken"];
                var data = _partyService.Create(prt);
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
            var data = _partyService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, PartyMaster prt)
        {

            try
            {
                var data = _partyService.Update(id, prt);
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
            var data = _partyService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
