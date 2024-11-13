using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class PartyMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string PrtId { get; set; }
        public string UsmId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string PrtName { get; set; }
        [Display(Name = "Contact No")]
        [Required]
        public string PrtContactNo { get; set; }

        [Display(Name = "City")]
        public string PrtCity { get; set; }

        [Display(Name = "Status")]
        public bool PrtStatus { get; set; }
    }
}
