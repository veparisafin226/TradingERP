using Microsoft.AspNetCore.Mvc;

namespace TradingERP.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
