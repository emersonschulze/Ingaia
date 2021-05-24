using TesteIngaia.Entity;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TesteIngaia.Data
{
    public class Seed
    {
        public static void SeedData(IMongoCollection<ValorUnidadeMedida> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<ValorUnidadeMedida> GetPreconfiguredProducts()
        {
            return new List<ValorUnidadeMedida>()
            {
                new ValorUnidadeMedida {Id = 12, unidadeMedida = "metros quadrados", valor = 20.00},
                new ValorUnidadeMedida {Id = 11,unidadeMedida = "metros cubicos", valor = 60.20 },
                new ValorUnidadeMedida {Id = 13, unidadeMedida = "litros", valor = 5.64}
            };
        }
    }
}
