using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;
        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var data = _itemService.ListByUser(userId);
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
        public IActionResult Create(ItemMaster itm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                itm.UsmId = Request.Cookies["admToken"];
                var data = _itemService.Create(itm);
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
            var data = _itemService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, ItemMaster itm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var data = _itemService.Update(id, itm);
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
            var data = _itemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
