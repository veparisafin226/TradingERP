using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class PumpMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string PmpId { get; set; }
        public string UsmId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string PmpName { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string PmpAddress { get; set; }

        [Display(Name = "City")]
        public string PmpCity { get; set; }

        [Display(Name = "Status")]
        public bool PmpStatus { get; set; }
    }
}
