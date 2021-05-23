using API_1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_1.Repository.Interface
{
    public interface IValorUnidadeMedidaRepository
    {
        // api/[GET]
        Task<IEnumerable<ValorUnidadeMedida>> GetAllTodos();

        // api/1/[GET]
        Task<ValorUnidadeMedida> GetTodo(long id);

        // api/[POST]
        Task Create(ValorUnidadeMedida todo);

        // api/[PUT]
        Task<bool> Update(ValorUnidadeMedida todo);

        // api/1/[DELETE]
        Task<bool> Delete(long id);

        Task<long> GetNextId();
    }
}
