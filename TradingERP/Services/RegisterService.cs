using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class RegisterService
    {
        private readonly IMongoCollection<RegisterMaster> registerMaster;
        public RegisterService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            registerMaster = database.GetCollection<RegisterMaster>("RegisterMaster");
        }
        public List<RegisterMaster> ListByUser(string userId)
        {
            var data = registerMaster.Find(t => t.UsmId == userId).ToList().OrderByDescending(t => t.RgmDate).ToList();
            return data;
        }

        public List<RegisterMaster> MonthListByUser(string userId)
        {
            var data = registerMaster.Find(t => t.UsmId == userId).ToList().OrderByDescending(t => t.RgmDate).ToList();
            data = data.Where(t=>t.RgmDate.Month == DateTime.Now.Month && t.RgmDate.Year==DateTime.Now.Year).ToList();
            return data;
        }

        public List<RegisterMaster> MonthListByUserSearch(string userId,int month,int year)
        {
            var data = registerMaster.Find(t => t.UsmId == userId).ToList().OrderByDescending(t => t.RgmDate).ToList();
            data = data.Where(t => t.RgmDate.Month == month && t.RgmDate.Year == year).ToList();
            return data;
        }

        public string Create(RegisterMaster rgm)
        {
            var response = "";
            try
            {
                registerMaster.InsertOne(rgm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public RegisterMaster GetById(string id)
        {
            var data = registerMaster.Find(t=>t.RgmId == id).FirstOrDefault();
            return data;
        }

        public string Update(String id, RegisterMaster rgm)
        {
            var response = "";
            try
            {
                rgm.RgmId = id;
                registerMaster.ReplaceOne(t => t.RgmId == id, rgm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = registerMaster.DeleteOne(t => t.RgmId == id);

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
