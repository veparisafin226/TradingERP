using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class DriverMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string DrmId { get; set; }
        public string UsmId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string DrmName { get; set; }
        [Display(Name = "Contact No")]
        [Required]
        public string DrmContactNo { get; set; }

        [Display(Name = "Status")]
        public bool DrmStatus { get; set; }
        
    }
}
