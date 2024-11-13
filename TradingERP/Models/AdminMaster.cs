using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TradingERP.Models
{
    public class AdminMaster
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AdmId { get; set; }

        [BsonElement("admUsername")]
        public string AdmUsername { get; set; }

        [BsonElement("admEmail")]
        public string AdmEmail { get; set; }

        [BsonElement("admPassword")]
        public string AdmPassword { get; set; }

        [BsonElement("admStatus")]
        public bool AdmStatus { get; set; }
    }

    public class AdminLogin
    {
        public string id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
    }
}
