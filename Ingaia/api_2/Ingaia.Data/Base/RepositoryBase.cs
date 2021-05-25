using Ingaia.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ingaia.Data.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        protected readonly IBancoContext _context;
        protected IMongoCollection<TEntity> _entities;

        public RepositoryBase(IBancoContext context)
        {
            _context = context;
            _entities = _context.GetCollection<TEntity>(typeof(TEntity).Name);

        }

        public Task<TEntity> BuscarId(long id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("Id", id);
            return _entities.Find(filter).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<TEntity>> BuscarTodos()
        {
            return await _entities .Find(_ => true).ToListAsync();
        }

        public async Task Incluir(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " O Objeto esta nulo.");
            }
            await _entities.InsertOneAsync(obj);
        }

        public async Task<bool> Remover(long id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("Id", id);
            DeleteResult deleteResult = await _entities.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> Atualizar(TEntity obj)
        {

            ReplaceOneResult updateResult =  await _entities.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", obj.ToBson()), obj);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

        }

        public async Task<long> IncrementarId()
        {
            return await _entities.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}