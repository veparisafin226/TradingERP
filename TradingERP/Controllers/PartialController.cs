using Microsoft.AspNetCore.Mvc;
using TradingERP.Models;
using TradingERP.Services;

namespace TradingERP.Controllers
{
    public class PartialController : Controller
    {
        private readonly PartyService _partyService;
        private readonly SiteService _siteService;
        private readonly VehicleNoService _vehicleNoService;
        private readonly ItemService _itemService;
        private readonly DealerService _dealerService;
        private readonly LizService _lizService;
        public PartialController(PartyService partyService, SiteService siteService, VehicleNoService vehicleNoService, ItemService itemService, DealerService dealerService, LizService lizService)
        {
            _partyService = partyService;
            _siteService = siteService;
            _vehicleNoService = vehicleNoService;
            _itemService = itemService;
            _dealerService = dealerService;
            _lizService = lizService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PartyList()
        {
            var userId = Request.Cookies["AdmToken"];
            var partyList = _partyService.ActiveListByUser(userId);
            return PartialView("_PartyPartial", partyList);
        }
       

        [HttpPost]
        public IActionResult AddParty(PartyMaster prt)
        {
            try
            {
                var userId = Request.Cookies["AdmToken"];
                prt.UsmId = userId;
                var result = _partyService.Create(prt);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Erro Occurred");
            }
        }

        public IActionResult SiteList()
        {
            var userId = Request.Cookies["AdmToken"];
            var siteList = _siteService.ActiveListByUser(userId);
            return PartialView("_SitePartial", siteList);
        }


        [HttpPost]
        public IActionResult AddSite(SiteMaster stm)
        {
            try
            {
                var userId = Request.Cookies["AdmToken"];
                stm.UsmId = userId;
                var result = _siteService.Create(stm);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Erro Occurred");
            }
        }

        public IActionResult VNList()
        {
            var userId = Request.Cookies["AdmToken"];
            var vnList = _vehicleNoService.ActiveListByUser(userId);
            return PartialView("_VehicleNoPartial", vnList);
        }

        [HttpPost]
        public IActionResult AddVehicleNo(VehicleNoMaster vn)
        {
            try
            {
                var userId = Request.Cookies["AdmToken"];
                vn.UsmId = userId;
                var result = _vehicleNoService.Create(vn);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Erro Occurred");
            }
        }

        public IActionResult ItemList()
        {
            var userId = Request.Cookies["AdmToken"];
            var itemList = _itemService.ActiveListByUser(userId);
            return PartialView("_ItemPartial", itemList);
        }

        [HttpPost]
        public IActionResult AddItem(ItemMaster itm)
        {
            try
            {
                var userId = Request.Cookies["AdmToken"];
                itm.UsmId = userId;
                var result = _itemService.Create(itm);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Erro Occurred");
            }
        }

        public IActionResult DealerList()
        {
            var userId = Request.Cookies["AdmToken"];
            var dealerList = _dealerService.ActiveListByUser(userId);
            return PartialView("_DealerPartial", dealerList);
        }


        [HttpPost]
        public IActionResult AddDealer(DealerMaster dlr)
        {
            try
            {
                var userId = Request.Cookies["AdmToken"];
                dlr.UsmId = userId;
                var result = _dealerService.Create(dlr);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Erro Occurred");
            }
        }

        public IActionResult LizList()
        {
            var userId = Request.Cookies["AdmToken"];
            var dealerList = _lizService.ActiveListByUser(userId);
            return PartialView("_LizPartial", dealerList);
        }


        [HttpPost]
        public IActionResult AddLiz(LizMaster lzm)
        {
            try
            {
                var userId = Request.Cookies["AdmToken"];
                lzm.UsmId = userId;
                var result = _lizService.Create(lzm);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Erro Occurred");
            }
        }
    }
}
