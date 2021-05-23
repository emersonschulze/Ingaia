using API_1.Data.Interface;
using API_1.Entity;
using API_1.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_1.Repository
{
    public class ValorUnidadeMedidaRepository : IValorUnidadeMedidaRepository
    {
        private readonly IBancoContext _context;

        public ValorUnidadeMedidaRepository(IBancoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ValorUnidadeMedida>> GetAllTodos()
        {
            return await _context
                            .ValorUnidadeMedidas
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<ValorUnidadeMedida> GetTodo(long id)
        {
            FilterDefinition<ValorUnidadeMedida> filter = Builders<ValorUnidadeMedida>.Filter.Eq(m => m.Id, id);
            return _context
                    .ValorUnidadeMedidas
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(ValorUnidadeMedida todo)
        {
            await _context.ValorUnidadeMedidas.InsertOneAsync(todo);
        }
        public async Task<bool> Update(ValorUnidadeMedida todo)
        {
            ReplaceOneResult updateResult =
                await _context
                        .ValorUnidadeMedidas
                        .ReplaceOneAsync(
                            filter: g => g.Id == todo.Id,
                            replacement: todo);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<ValorUnidadeMedida> filter = Builders<ValorUnidadeMedida>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .ValorUnidadeMedidas
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> GetNextId()
        {
            return await _context.ValorUnidadeMedidas.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}