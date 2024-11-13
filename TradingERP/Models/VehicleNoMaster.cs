using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class VehicleNoMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string VnmId { get; set; }

        public string UsmId { get; set; }

        [Display(Name = "Vehicle No")]
        [Required]
        public string VnmNo { get; set; }
        
        [Display(Name = "Status")]
        public bool VnmStatus { get; set; }
    }
}
