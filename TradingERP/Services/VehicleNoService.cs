using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class VehicleNoService
    {
        private readonly IMongoCollection<VehicleNoMaster> vehicleNoMaster;
        public VehicleNoService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            vehicleNoMaster = database.GetCollection<VehicleNoMaster>("VehicleNoMaster");
        }

        public List<VehicleNoMaster> ListByUser(string userId)
        {
            var data = vehicleNoMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.VnmNo).ToList();
            return data;
        }

        public List<VehicleNoMaster> ActiveListByUser(string userId)
        {
            var data = vehicleNoMaster.Find(t => t.UsmId == userId && t.VnmStatus == true).ToList().OrderBy(t => t.VnmNo).ToList();
            return data;
        }

        public string Create(VehicleNoMaster vnm)
        {
            var response = "";
            try
            {
                vnm.VnmStatus = true;
                vehicleNoMaster.InsertOne(vnm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, VehicleNoMaster vnm)
        {
            var response = "";
            try
            {
                vnm.VnmId = id;
                vehicleNoMaster.ReplaceOne(t => t.VnmId == id, vnm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public VehicleNoMaster GetById(string id)
        {
            var data = vehicleNoMaster.Find(t => t.VnmId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                
                var result = vehicleNoMaster.DeleteOne(t => t.VnmId == id);

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
