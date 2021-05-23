using TesteIngaia.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteIngaia.Data.Interface
{
    public interface IBancoContext
    {
        IMongoCollection<ValorUnidadeMedida> ValorUnidadeMedidas { get; }
    }
}
