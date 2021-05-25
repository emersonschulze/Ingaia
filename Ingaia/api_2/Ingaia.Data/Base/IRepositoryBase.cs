using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ingaia.Data.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> BuscarTodos();
        Task<TEntity> BuscarId(long id);
        Task Incluir(TEntity obj);
        Task<bool> Atualizar(TEntity obj);
        Task<bool> Remover(long id);
        Task<long> IncrementarId();

    }
}

