using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class DieselMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string DsmId { get; set; }
        public string UsmId { get; set; }
        [Display(Name ="Date")]
        [Required]
        public DateTime DsmDate { get; set; }
        [Display(Name = "Pump Station")]
        [Required]
        public string PmpId { get; set; }
        [Display(Name = "Diesel Qty")]
        [Required]
        public string DsmQty { get; set; }

        [Display(Name = "Diesel Amount")]
        public string DsmAMount { get; set; }

       
    }
}
