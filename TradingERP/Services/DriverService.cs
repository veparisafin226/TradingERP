using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<DriverMaster> driverMaster;
        public DriverService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            driverMaster = database.GetCollection<DriverMaster>("DriverMaster");
        }

        public List<DriverMaster> ListByUser(string userId)
        {
            var data = driverMaster.Find(t=>t.UsmId == userId).ToList().OrderBy(t=>t.DrmName).ToList();
            return data;
        }

        public List<DriverMaster> ActiveListByUser(string userId)
        {
            var data = driverMaster.Find(t => t.UsmId == userId && t.DrmStatus==true).ToList().OrderBy(t => t.DrmName).ToList();
            return data;
        }

        public string Create(DriverMaster drm)
        {
            var response = "";
            try
            {
                drm.DrmStatus = true;
                driverMaster.InsertOne(drm);
                response = "Success";
            }
            catch (Exception ex) {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id,DriverMaster drm)
        {
            var response = "";
            try
            {
                drm.DrmId = id;   
                driverMaster.ReplaceOne(t=>t.DrmId==id, drm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public DriverMaster GetById(string id)
        {
            var data = driverMaster.Find(t => t.DrmId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var filter = Builders<DriverMaster>.Filter.Eq("DrmId", new ObjectId(id));
                var result = driverMaster.DeleteOne(t=>t.DrmId==id);

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
