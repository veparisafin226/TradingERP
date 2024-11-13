using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class PartyService
    {
        private readonly IMongoCollection<PartyMaster> partyMaster;
        public PartyService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            partyMaster = database.GetCollection<PartyMaster>("PartyMaster");
        }

        public List<PartyMaster> ListByUser(string userId)
        {
            var data = partyMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.PrtName).ToList();
            return data;
        }

        public List<PartyMaster> ActiveListByUser(string userId)
        {
            var data = partyMaster.Find(t => t.UsmId == userId && t.PrtStatus == true).ToList().OrderBy(t => t.PrtName).ToList();
            return data;
        }

        public string Create(PartyMaster prt)
        {
            var response = "";
            try
            {
                prt.PrtStatus = true;
                partyMaster.InsertOne(prt);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, PartyMaster prt)
        {
            var response = "";
            try
            {
                prt.PrtId = id;
                partyMaster.ReplaceOne(t => t.PrtId == id, prt);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public PartyMaster GetById(string id)
        {
            var data = partyMaster.Find(t => t.PrtId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = partyMaster.DeleteOne(t => t.PrtId == id);

                response = result.IsAcknowledged && result.DeletedCount > 0
                    ? "Success"
                    : "No record was deleted";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }
    }
}
