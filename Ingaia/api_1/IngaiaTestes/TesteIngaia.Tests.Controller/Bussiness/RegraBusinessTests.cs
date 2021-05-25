using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TesteIngaia.Business;
using TesteIngaia.Entity;

namespace TesteIngaia.Tests.Controller
{

    [TestClass]
    public class RegraBusinessTests
    {

        RegrasBusiness regra;

        [TestInitialize]
        public void InitializeForTests()
        {
           
        }

        [TestMethod]
        public void validarValorAcimaDoPermitido()
        {
            var item = new ValorUnidadeMedida { Id = 1, unidadeMedida = "Litro", valor = 10001 };
            regra = new RegrasBusiness(item);

            var result = regra.regraValorPermitido();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void validarValorAbaixoDoPermitido()
        {
            var item = new ValorUnidadeMedida { Id = 1, unidadeMedida = "Litro", valor = 9 };
            regra = new RegrasBusiness(item);

            var result = regra.regraValorPermitido();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void validarValorDentroDoPermitido()
        {
            var item = new ValorUnidadeMedida { Id = 1, unidadeMedida = "Litro", valor = 15.23 };
            regra = new RegrasBusiness(item);

            var result = regra.regraValorPermitido();
            Assert.IsTrue(result);
        }
    }
}