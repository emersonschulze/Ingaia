using TesteIngaia.Data.Interface;
using TesteIngaia.Entity;
using TesteIngaia.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIngaia.Repository
{
    public class ValorUnidadeMedidaRepository : IValorUnidadeMedidaRepository
    {
        private readonly IBancoContext _context;

        public ValorUnidadeMedidaRepository(IBancoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ValorUnidadeMedida>> BuscarTodos()
        {
            return await _context
                            .ValorUnidadeMedidas
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<ValorUnidadeMedida> BuscarId(long id)
        {
            FilterDefinition<ValorUnidadeMedida> filter = Builders<ValorUnidadeMedida>.Filter.Eq(m => m.Id, id);
            return _context
                    .ValorUnidadeMedidas
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Inserir(ValorUnidadeMedida obj)
        {
            await _context.ValorUnidadeMedidas.InsertOneAsync(obj);
        }

        public async Task<bool> Atualizar(ValorUnidadeMedida obj)
        {
            ReplaceOneResult updateResult =
                await _context
                        .ValorUnidadeMedidas
                        .ReplaceOneAsync(
                            filter: g => g.Id == obj.Id,
                            replacement: obj);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        
        public async Task<bool> Deletar(long id)
        {
            FilterDefinition<ValorUnidadeMedida> filter = Builders<ValorUnidadeMedida>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .ValorUnidadeMedidas
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> IncrementarId()
        {
            return await _context.ValorUnidadeMedidas.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}