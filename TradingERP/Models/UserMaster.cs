using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TradingERP.Models
{
    public class UserMaster
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UsmId { get; set; }

        [Display(Name ="Name")]
        [Required]
        public string UsmName { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string UsmEmail { get; set; }
        [Display(Name = "Contact")]
        [Required]
        public string UsmContact { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string UsmPassword { get; set; }
        [Display(Name = "Status")]
        public bool UsmStatus { get; set; }
    }
}
