using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger,UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var response = "";
            try
            {
                var data = _userService.Login(email, password);
                if (data.message == "Success")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("admName", data.name,options);
                    Response.Cookies.Append("admToken", data.id, options);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.response = data.message;
                }
            }
            catch (Exception ex)
            {
                ViewBag.response = "Error Occurred";
            }
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("admName");
            Response.Cookies.Delete("admToken");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
