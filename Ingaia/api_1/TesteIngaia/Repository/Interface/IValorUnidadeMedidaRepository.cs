using TesteIngaia.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIngaia.Repository.Interface
{
    public interface IValorUnidadeMedidaRepository
    {
        Task<IEnumerable<ValorUnidadeMedida>> BuscarTodos();

        Task<ValorUnidadeMedida> BuscarId(long id);

        Task Inserir(ValorUnidadeMedida obj);

        Task<bool> Atualizar(ValorUnidadeMedida obj);

        Task<bool> Deletar(long id);

        Task<long> IncrementarId();
    }
}
