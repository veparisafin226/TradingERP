using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserMaster> userMaster;
        public UserService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            userMaster = database.GetCollection<UserMaster>("UserMaster");
        }

        public string Create(UserMaster data)
        {
            var response = "";
            try
            {
                userMaster.InsertOne(data);
                response = "Success";
            }
            catch(Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }
        public List<UserMaster> ListAll()
        {
            var data = userMaster.Find(t => true).ToList().OrderBy(t => t.UsmName).ToList();
            return data;
        }

        public AdminLogin Login(string email, string password)
        {
            var response = new AdminLogin();
            try
            {
                var data = userMaster.Find(t => t.UsmEmail == email && t.UsmPassword == password).FirstOrDefault();
                if (data == null)
                {
                    response.message = "Invalid login!";
                }
                else
                {
                    if (data.UsmStatus == false)
                    {
                        response.message = "Your account is de-activated";
                    }
                    else
                    {
                        response.name = data.UsmName;
                        response.id = data.UsmId;
                        response.message = "Success";
                    }
                }
            }
            catch (Exception)
            {
                response.message = "Error Occured";
            }
            return response;
        }
    }
}
