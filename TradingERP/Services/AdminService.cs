using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class AdminService
    {
        private readonly IMongoCollection<AdminMaster> adminMaster;
        public AdminService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            adminMaster = database.GetCollection<AdminMaster>("AdminMaster");
        }

        public string Create(AdminMaster data)
        {
            var message = "";
            try
            {
                adminMaster.InsertOne(data);
                message = "Success";
            }
            catch(Exception ex)
            {
                message = "Error Generate";
            }
            return message;
        }

        public AdminLogin Login(string email,string password)
        {
            var response = new AdminLogin();
            try
            {
                var data = adminMaster.Find(t => t.AdmEmail == email && t.AdmPassword == password).FirstOrDefault();
                if (data == null)
                {
                    response.message = "Invalid login!";
                }
                else
                {
                    if (data.AdmStatus == false)
                    {
                        response.message = "Your account is de-activated";
                    }
                    else
                    {
                        response.name = data.AdmUsername;
                        
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
