using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class LizMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string LzmId { get; set; }
        public string UsmId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string LzmName { get; set; }
        [Display(Name = "Contact No")]
        [Required]
        public string LzmContactNo { get; set; }

        [Display(Name = "City")]
        public string LzmCity { get; set; }

        [Display(Name = "Status")]
        public bool LzmStatus { get; set; }
    }
}
