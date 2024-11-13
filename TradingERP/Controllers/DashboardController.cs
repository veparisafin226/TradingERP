using Microsoft.AspNetCore.Mvc;

namespace TradingERP.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
