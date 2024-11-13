using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class DealerService
    {
        private readonly IMongoCollection<DealerMaster> dealerMaster;
        public DealerService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            dealerMaster = database.GetCollection<DealerMaster>("DealerMaster");
        }

        public List<DealerMaster> ListByUser(string userId)
        {
            var data = dealerMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.DlrName).ToList();
            return data;
        }

        public List<DealerMaster> ActiveListByUser(string userId)
        {
            var data = dealerMaster.Find(t => t.UsmId == userId && t.DlrStatus == true).ToList().OrderBy(t => t.DlrName).ToList();
            return data;
        }

        public string Create(DealerMaster dlr)
        {
            var response = "";
            try
            {
                dlr.DlrStatus = true;
                dealerMaster.InsertOne(dlr);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, DealerMaster dlr)
        {
            var response = "";
            try
            {
                dlr.DlrId = id;
                dealerMaster.ReplaceOne(t => t.DlrId == id, dlr);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public DealerMaster GetById(string id)
        {
            var data = dealerMaster.Find(t => t.DlrId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {
                var result = dealerMaster.DeleteOne(t => t.DlrId == id);

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
