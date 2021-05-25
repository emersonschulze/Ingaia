using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ingaia.Data.Context
{
    public class BancoContext : IBancoContext
    {
        private readonly IMongoDatabase _db;
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public BancoContext(IOptions<Settings> options)
        {
            _mongoClient = new MongoClient(options.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<ValorUnidadeMedida> GetCollection<ValorUnidadeMedida>(string name)
        {
            return _db.GetCollection<ValorUnidadeMedida>("ValorUnidadeMedidas");
        }


    }


}