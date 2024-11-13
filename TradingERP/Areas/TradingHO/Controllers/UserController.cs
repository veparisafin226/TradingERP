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
            var data = userService.ListAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserMaster user)
        {
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
    }
}
