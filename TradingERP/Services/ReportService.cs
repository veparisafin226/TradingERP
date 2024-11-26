using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TradingERP.Models;


namespace TradingERP.Services
{
    public class ReportService
    {
        private readonly IMongoCollection<RegisterMaster> registerMaster;
        public ReportService(IOptions<DatabaseConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            var database = client.GetDatabase(dbConfig.Value.DatabaseName);
            registerMaster = database.GetCollection<RegisterMaster>("RegisterMaster");
        }

        public List<RegisterMaster> RgReportByParty(string usmId,string party,int month,int year)
        {
           
            var data = new List<RegisterMaster>();
            data = registerMaster.Find(t => t.UsmId == usmId && t.RgmParty == party).ToList();
            data = data.Where(t=>t.RgmDate.Month==month && t.RgmDate.Year==year).ToList();
            return data.OrderBy(t=>t.RgmDate).ToList();
        }
    }
}
