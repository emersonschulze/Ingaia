using Ingaia.Data.Base;
using Ingaia.Data.Context;
using Ingaia.Dominio.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteIngaia2.Repository.Interface;

namespace TesteIngaia.Repository
{
    public class ValorUnidadeMedidaRepository : RepositoryBase<ValorUnidadeMedida>, IValorUnidadeMedidaRepository
    {
        public ValorUnidadeMedidaRepository(BancoContext context) : base(context)
        {

        }
    }
}