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
            var userId = Request.Cookies["admToken"];
            var data = _itemService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemMaster itm)
        {

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
            var data = _itemService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id, ItemMaster itm)
        {

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
            var data = _itemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
