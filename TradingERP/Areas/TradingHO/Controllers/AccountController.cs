using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;


namespace TradingERP.Areas.TradingHO.Controllers
{
    [Area("TradingHO")]
    public class AccountController : Controller
    {
        private readonly AdminService adminService;
        public AccountController(AdminService _adminService)
        {
            adminService = _adminService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            var response = "";
            try
            {
                var data = adminService.Login(email, password);
                if (data.message == "Success")
                {
                    Response.Cookies.Append("THOAdmin", data.name);
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    ViewBag.response = data.message;
                }
            }
            catch(Exception ex)
            {
                ViewBag.response = "Error Occurred";
            }
            return View();
        }

        public IActionResult Create()
        {
            var data = new AdminMaster();
            data.AdmEmail = "superadmin@gmail.com";
            data.AdmStatus = true;
            data.AdmUsername = "SuperAdmin";
            data.AdmPassword = "SA@123";
            var response = adminService.Create(data);
            return Json(response);
        }
    }
}
