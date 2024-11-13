using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class SiteService
    {
        private readonly IMongoCollection<SiteMaster> siteMaster;
        public SiteService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            siteMaster = database.GetCollection<SiteMaster>("SiteMaster");
        }

        public List<SiteMaster> ListByUser(string userId)
        {
            var data = siteMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.StmName).ToList();
            return data;
        }

        public List<SiteMaster> ActiveListByUser(string userId)
        {
            var data = siteMaster.Find(t => t.UsmId == userId && t.StmStatus == true).ToList().OrderBy(t => t.StmName).ToList();
            return data;
        }

        public string Create(SiteMaster stm)
        {
            var response = "";
            try
            {
                stm.StmStatus = true;
                siteMaster.InsertOne(stm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, SiteMaster stm)
        {
            var response = "";
            try
            {
                stm.StmId = id;
                siteMaster.ReplaceOne(t => t.StmId == id, stm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public SiteMaster GetById(string id)
        {
            var data = siteMaster.Find(t => t.StmId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = siteMaster.DeleteOne(t => t.StmId == id);

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
