﻿using Microsoft.Extensions.Options;
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

        public List<RegisterMaster> RgReportByParty(string usmId,string party,string fromDate,string toDate) {
            var data = registerMaster.Find(t => t.UsmId == usmId && t.RgmParty == party).ToList();
            if(fromDate!=null)
            {
                var fdate = Convert.ToDateTime(fromDate);
                data = data.Where(t => t.RgmDate >= fdate).ToList();
            }
            if (toDate != null)
            {
                var tdate = Convert.ToDateTime(toDate);
                data = data.Where(t=>t.RgmDate<=tdate).ToList();
            }
            return data.OrderBy(t=>t.RgmDate).ToList();
        }
    }
}
