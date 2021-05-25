using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingaia.Data.Context
{
   public interface IBancoContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
 
