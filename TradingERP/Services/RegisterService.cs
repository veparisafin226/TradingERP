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
    }
}
