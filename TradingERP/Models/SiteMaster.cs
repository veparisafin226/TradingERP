using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class SiteMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string StmId { get; set; }
        public string UsmId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string StmName { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string StmAddress { get; set; }

        [Display(Name = "Status")]
        public bool StmStatus { get; set; }
    }
}
