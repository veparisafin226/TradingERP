using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Areas.TradingHO.Controllers
{
    [Area("TradingHO")]
    public class UserController : Controller
    {
        private readonly UserService userService;
        public UserController(UserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["THOAdmin"]==null)
            {
                return RedirectToAction("Login", "Account");
            }
            var data = userService.ListAll();
            return View(data);
        }
        public IActionResult Create()
        {
            if (Request.Cookies["THOAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserMaster user)
        {
            if (Request.Cookies["THOAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                var response = userService.Create(user);
                if (response == "Success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Error Occurred";
                }
            }
            catch(Exception ex)
            {
                ViewBag.message = "Error Occurred";
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            if (Request.Cookies["THOAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var data = userService.GetById(id);
            return View(data);
        }



        [HttpPost]
        public IActionResult Edit(string id,UserMaster user)
        {
            if (Request.Cookies["THOAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                var response = userService.Update(id,user);
                if (response == "Success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Error Occurred";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error Occurred";
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var data = userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
