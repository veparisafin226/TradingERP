using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class DieselService
    {
        private readonly IMongoCollection<DieselMaster> dieselMaster;
        public DieselService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            dieselMaster = database.GetCollection<DieselMaster>("DieselMaster");
        }

        public List<DieselMaster> ListByUser(string userId)
        {
            var data = dieselMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.DsmDate).ToList();
            return data;
        }

       

        public string Create(DieselMaster dsm)
        {
            var response = "";
            try
            {

                dieselMaster.InsertOne(dsm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, DieselMaster dsm)
        {
            var response = "";
            try
            {
                dieselMaster.ReplaceOne(t => t.DsmId == id, dsm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public DieselMaster GetById(string id)
        {
            var data = dieselMaster.Find(t => t.DsmId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = dieselMaster.DeleteOne(t => t.DsmId == id);

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
