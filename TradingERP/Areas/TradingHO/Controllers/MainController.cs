using Microsoft.AspNetCore.Mvc;

namespace TradingERP.Areas.TradingHO.Controllers
{
    [Area("TradingHO")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            if (Request.Cookies["THOAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
