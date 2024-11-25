using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class RegisterController : Controller
    {
        private readonly PartyService _partyService;
        private readonly SiteService _siteService;
        private readonly VehicleNoService _vehicleNoService;
        private readonly ItemService _itemService;
        private readonly DriverService _driverService;
        private readonly PumpService _pumpService;
        private readonly DealerService _dealerService;
        private readonly RegisterService _registerService;
        private readonly LizService _lizService;
        public RegisterController(PartyService partyService, SiteService siteService,
            VehicleNoService vehicleNoService,ItemService itemService,
            DriverService driverService, PumpService pumpService,DealerService dealerService,RegisterService registerService,LizService lizService)
        {
            _partyService = partyService;
            _siteService = siteService;
            _vehicleNoService = vehicleNoService;
            _itemService = itemService;
            _driverService = driverService;
            _pumpService = pumpService;
            _dealerService = dealerService;
            _registerService = registerService;
            _lizService = lizService;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["AdmToken"];
            var data = _registerService.ListByUser(userId);
            return View(data);
        }

        public IActionResult Create()
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            ViewData["partyList"]=_partyService.ActiveListByUser(userId);
            ViewData["siteList"] = _siteService.ActiveListByUser(userId);
            ViewData["vehicleNoList"] = _vehicleNoService.ActiveListByUser(userId);
            ViewData["itemList"] = _itemService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["dealerList"] = _dealerService.ActiveListByUser(userId);
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterMaster rgm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            ViewData["partyList"] = _partyService.ActiveListByUser(userId);
            ViewData["siteList"] = _siteService.ActiveListByUser(userId);
            ViewData["vehicleNoList"] = _vehicleNoService.ActiveListByUser(userId);
            ViewData["itemList"] = _itemService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["dealerList"] = _dealerService.ActiveListByUser(userId);
            try
            {
                rgm.UsmId = Request.Cookies["AdmToken"];
                var response = _registerService.Create(rgm);
                if (response == "Success")
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    ViewBag.response = response;
                }
            }
            catch(Exception ex)
            {
                ViewBag.response = "Error Occurred";
            }
            return RedirectToAction("Create");
        }

        public IActionResult Edit(string id)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var data = _registerService.GetById(id);
            ViewData["partyList"] = _partyService.ActiveListByUser(userId);
            ViewData["siteList"] = _siteService.ActiveListByUser(userId);
            ViewData["vehicleNoList"] = _vehicleNoService.ActiveListByUser(userId);
            ViewData["itemList"] = _itemService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["dealerList"] = _dealerService.ActiveListByUser(userId);
            ViewData["lizList"] = _lizService.ActiveListByUser(userId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(string id,RegisterMaster rgm)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userId = Request.Cookies["admToken"];
            var data = _registerService.GetById(id);
            ViewData["partyList"] = _partyService.ActiveListByUser(userId);
            ViewData["siteList"] = _siteService.ActiveListByUser(userId);
            ViewData["vehicleNoList"] = _vehicleNoService.ActiveListByUser(userId);
            ViewData["itemList"] = _itemService.ActiveListByUser(userId);
            ViewData["driverList"] = _driverService.ActiveListByUser(userId);
            ViewData["pumpList"] = _pumpService.ActiveListByUser(userId);
            ViewData["dealerList"] = _dealerService.ActiveListByUser(userId);
            ViewData["lizList"] = _lizService.ActiveListByUser(userId);
            try
            {
                rgm.UsmId = Request.Cookies["AdmToken"];
                var response = _registerService.Update(id,rgm);
                if (response == "Success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.response = response;
                }
            }
            catch (Exception ex)
            {
                ViewBag.response = "Error Occurred";
            }
            return View(data);
        }

        public IActionResult Delete(string id)
        {
            if (Request.Cookies["admToken"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var data = _registerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
