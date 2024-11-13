using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class ItemMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ItmId { get; set; }

        public string UsmId { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string ItmName { get; set; }

        [Display(Name = "Status")]
        public bool ItmStatus { get; set; }
    }
}
