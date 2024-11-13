using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;

namespace TradingERP.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<ItemMaster> itemMaster;
        public ItemService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            itemMaster = database.GetCollection<ItemMaster>("ItemMaster");
        }

        public List<ItemMaster> ListByUser(string userId)
        {
            var data = itemMaster.Find(t => t.UsmId == userId).ToList().OrderBy(t => t.ItmName).ToList();
            return data;
        }

        public List<ItemMaster> ActiveListByUser(string userId)
        {
            var data = itemMaster.Find(t => t.UsmId == userId && t.ItmStatus == true).ToList().OrderBy(t => t.ItmName).ToList();
            return data;
        }

        public string Create(ItemMaster itm)
        {
            var response = "";
            try
            {
                itm.ItmStatus = true;
                itemMaster.InsertOne(itm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public string Update(String id, ItemMaster itm)
        {
            var response = "";
            try
            {
                itm.ItmId = id;
                itemMaster.ReplaceOne(t => t.ItmId == id, itm);
                response = "Success";
            }
            catch (Exception ex)
            {
                response = "Error Occurred";
            }
            return response;
        }

        public ItemMaster GetById(string id)
        {
            var data = itemMaster.Find(t => t.ItmId == id).FirstOrDefault();
            return data;
        }

        public string Delete(String id)
        {
            var response = "";
            try
            {

                var result = itemMaster.DeleteOne(t => t.ItmId == id);

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
