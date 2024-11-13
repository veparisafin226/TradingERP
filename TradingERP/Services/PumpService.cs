using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class PumpService
    {
        private readonly IMongoCollection<PumpMaster> pumpMaster;
        public PumpService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            pumpMaster = database.GetCollection<PumpMaster>("PumpMaster");
        }

        public List<PumpMaster> ListByUser(string userId)
        {
            var data = pumpMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.PmpName).ToList();
            return data;
        }

        public List<PumpMaster> ActiveListByUser(string userId)
        {
            var data = pumpMaster.Find(t => t.UsmId == userId && t.PmpStatus == true).ToList().OrderBy(t => t.PmpName).ToList();
            return data;
        }

        public string Create(PumpMaster pmp)
        {
            var response = "";
            try
            {
                pmp.PmpStatus = true;
                pumpMaster.InsertOne(pmp);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, PumpMaster pmp)
        {
            var response = "";
            try
            {
                pmp.PmpId = id;
                pumpMaster.ReplaceOne(t => t.PmpId == id, pmp);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public PumpMaster GetById(string id)
        {
            var data = pumpMaster.Find(t => t.PmpId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = pumpMaster.DeleteOne(t => t.PmpId == id);

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
