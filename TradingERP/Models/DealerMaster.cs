using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class DealerMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string DlrId { get; set; }
        public string UsmId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string DlrName { get; set; }
        [Display(Name = "Contact No")]
        [Required]
        public string DlrContactNo { get; set; }

        [Display(Name = "City")]
        public string DlrCity { get; set; }

        [Display(Name = "Status")]
        public bool DlrStatus { get; set; }
    }
}
