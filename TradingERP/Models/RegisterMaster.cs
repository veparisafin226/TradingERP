using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    [BsonIgnoreExtraElements]
    public class RegisterMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string RgmId { get; set; }

        [Display(Name ="Date")]
        public DateTimeOffset RgmDate { get; set; }
        [Display(Name = "Party")]
        public string RgmParty { get; set; }
        [Display(Name = "Site")]
        public string RgmSite { get; set; }
        [Display(Name = "Vehicle No")]
        public string RgmVehicleNo { get; set; }
        [Display(Name = "Item")]
        public string RgmItem { get; set; }
        [Display(Name = "Qty")]
        public string RgmQty { get; set; }
        [Display(Name = "Rate")]
        public string RgmRate { get; set; }
        [Display(Name = "Total")]
        public string RgmTotal { get; set; }
       
        [Display(Name = "Dealer")]
        public string RgmDealer { get; set; }
        [Display(Name = "Rate")]
        public string RgmRate1 { get; set; }
        [Display(Name = "Total")]
        public string RgmTotal1 {  get; set; }
       
        [Display(Name = "Type")]
        public string RgmType { get; set; }
        //[Display(Name = "Pump")]
        //public string RgmPump { get; set; }
        //[Display(Name = "Diesel")]
        //public string RgmDiesel { get; set; }
        //[Display(Name = "Diesel Amount")]
        //public string RgmDieselTotal { get; set; }
        public string UsmId { get; set; }
    }
}
