using TesteIngaia.Config;
using TesteIngaia.Data.Interface;
using TesteIngaia.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIngaia.Data
{
    public class BancoContext : IBancoContext
    {
        private readonly IMongoDatabase _db;

        public BancoContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        
        }
        public IMongoCollection<ValorUnidadeMedida> ValorUnidadeMedidas => _db.GetCollection<ValorUnidadeMedida>("ValorUnidadeMedidas");

    }
}
