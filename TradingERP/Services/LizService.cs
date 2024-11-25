using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class LizService
    {
        private readonly IMongoCollection<LizMaster> lizMaster;
        public LizService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            lizMaster = database.GetCollection<LizMaster>("LizMaster");
        }

        public List<LizMaster> ListByUser(string userId)
        {
            var data = lizMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.LzmName).ToList();
            return data;
        }

        public List<LizMaster> ActiveListByUser(string userId)
        {
            var data = lizMaster.Find(t => t.UsmId == userId && t.LzmStatus == true).ToList().OrderBy(t => t.LzmName).ToList();
            return data;
        }

        public string Create(LizMaster lzm)
        {
            var response = "";
            try
            {
                lzm.LzmStatus = true;
                lizMaster.InsertOne(lzm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, LizMaster lzm)
        {
            var response = "";
            try
            {
                lzm.LzmId = id;
                lizMaster.ReplaceOne(t => t.LzmId == id, lzm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public LizMaster GetById(string id)
        {
            var data = lizMaster.Find(t => t.LzmId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = lizMaster.DeleteOne(t => t.LzmId == id);

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
