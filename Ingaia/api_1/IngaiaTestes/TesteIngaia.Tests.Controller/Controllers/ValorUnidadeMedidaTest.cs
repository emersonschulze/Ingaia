using System.Collections.Generic;
using System.Threading.Tasks;
using TesteIngaia.Controllers;
using TesteIngaia.Entity;
using TesteIngaia.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Ingaia.Tests.Controllers
{
    [TestClass]
    public class ValorUnidadeMedidaTest
    {

        ValorUnidadeMedidaController controller;

        [TestInitialize]
        public void InitializeForTests()
        {
            //repositoryMock
            //repository = new ValorUnidadeMedidaMock();
            //controller = new ValorUnidadeMedidaController(repository);
        }

        [TestMethod]
        public async Task DeveTrazerMensagemRegistroNaoEncontrado()
        {

            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync((ValorUnidadeMedida)null);


            controller = new ValorUnidadeMedidaController(repo.Object);



            var result = await controller.ListarRegistro(1);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeveListarResultadoPorId_ValidarTipoRetorno()
        {

            var item = RegistroFake();

            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync(item);

            controller = new ValorUnidadeMedidaController(repo.Object);

            var result = await controller.ListarRegistro(1);
            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));

         }

        [TestMethod]
        public async Task DeveListarResultadoPorId_Conteudo()
        {

            var item = RegistroFake();

            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync(item);

            controller = new ValorUnidadeMedidaController(repo.Object);

            var result = await controller.ListarRegistro(1) ;

            var dado = result.Result as ObjectResult;
                Assert.IsTrue(dado.Value.Equals(item));

        }

        [TestMethod]
        public async Task DeveListarTodosOsRegistros()
        {
            var itensFake = ListaDadosFake();

            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarTodos()).ReturnsAsync(itensFake);
            
            controller = new ValorUnidadeMedidaController(repo.Object);
            var itens = await controller.ListarRegistros();
            
            var result = itens.Result as ObjectResult;

            List<ValorUnidadeMedida> lista = new List<ValorUnidadeMedida>();

            lista.AddRange((IEnumerable<ValorUnidadeMedida>)result.Value);
            Assert.AreEqual(lista.Count, 4);
        }


        [TestMethod]
        public async Task DeveInserirUmRegistro()
        {

            var item = RegistroFake();
            var repo = new Mock<IValorUnidadeMedidaRepository>();
           
            controller = new ValorUnidadeMedidaController(repo.Object);

            var result = await controller.Inserir(item);

            var dado = (result.Result as OkObjectResult).Value as ValorUnidadeMedida;
            Assert.IsTrue(item.Equals(dado));
            

        }

        [TestMethod]
        public async Task DeveRetornarMensagemCampoObrigatorioAoInserirUmRegistro()
        {

            var item = new ValorUnidadeMedida { Id = 1, valor = 11.00 };
            var repo = new Mock<IValorUnidadeMedidaRepository>();

            controller = new ValorUnidadeMedidaController(repo.Object);
            controller.ModelState.AddModelError("Unidade de medidade obtrigatória", "test");

            var result = await controller.Inserir(item);

            var dado = result.Result as StatusCodeResult ;
            Assert.IsTrue(dado.StatusCode.Equals(400));


        }

        [TestMethod]
        public async Task DeveRetornarMensagemRegistroNaoEncontradoAoTentarAtualizarUmRegistro()
        {
            var itemVelho = RegistroFake();
            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync((ValorUnidadeMedida)null);


            var itemId = itemVelho.Id;
            var itemAtualizado = new ValorUnidadeMedida { unidadeMedida = "Litro", valor = 31.30 };

            controller = new ValorUnidadeMedidaController(repo.Object);


            var result = await controller.Atualizar(itemId, itemAtualizado);
            
            
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));

        }

        [TestMethod]
        public async Task DeveAtualizarUmRegistro()
        {

            var itemVelho = RegistroFake();
            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync(itemVelho);


            var itemId = itemVelho.Id;
            var itemAtualizado = new ValorUnidadeMedida { unidadeMedida = "Litro", valor = 31.30 };

            controller = new ValorUnidadeMedidaController(repo.Object);


            var result = await controller.Atualizar(itemId, itemAtualizado);

            var dado = (result.Result as OkObjectResult).Value as ValorUnidadeMedida;
            Assert.IsFalse(itemVelho.Equals(dado));

        }


        [TestMethod]
        public async Task DeveRetornarMensagemRegistroNaoEncontradoAoTentarDeletarUmRegistro()
        {
            var itemVelho = RegistroFake();
            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync((ValorUnidadeMedida)null);

            var itemId = itemVelho.Id;

            controller = new ValorUnidadeMedidaController(repo.Object);

            var result = await controller.Deletar(itemId);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

        [TestMethod]
        public async Task DeveDeletarUmRegistro()
        {

            var item = RegistroFake();
            var repo = new Mock<IValorUnidadeMedidaRepository>();
            repo.Setup(r => r.BuscarId(It.IsAny<long>())).ReturnsAsync(item);

            controller = new ValorUnidadeMedidaController(repo.Object);

            var result = await controller.Deletar(item.Id);

            Assert.IsInstanceOfType(result, typeof(OkResult));

        }


       
        protected IEnumerable<ValorUnidadeMedida> ListaDadosFake()
        {
            List<ValorUnidadeMedida> registros = new List<ValorUnidadeMedida>();

            registros.Add(new ValorUnidadeMedida { Id = 1, unidadeMedida = "Litro", valor = 11.00 });
            registros.Add(new ValorUnidadeMedida { Id = 2, unidadeMedida = "Metro Quadrado", valor = 18.19 });
            registros.Add(new ValorUnidadeMedida { Id = 3, unidadeMedida = "Metro Cubico", valor = 328.12 });
            registros.Add(new ValorUnidadeMedida { Id = 4, unidadeMedida = "Quilos", valor = 110.01 });


            return registros;
        }

        protected ValorUnidadeMedida RegistroFake()
        {

            return new ValorUnidadeMedida { Id = 1, unidadeMedida = "Litro", valor = 11.00 };
          
        }


    }
}
