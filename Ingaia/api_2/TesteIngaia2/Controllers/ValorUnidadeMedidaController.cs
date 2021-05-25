using Ingaia.Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TesteIngaia2.Repository.Interface;

namespace TesteIngaia.Controllers
{

    [Produces("application/json")]
    [Route("api/v2/ValorUnidadeMedida")]
    [ApiController]
    public class ValorUnidadeMedidaController : ControllerBase
    {
        private readonly IValorUnidadeMedidaRepository _repo;
     
        public ValorUnidadeMedidaController(IValorUnidadeMedidaRepository repository)
        {
            _repo = repository;
           
        }

        /// <summary>
        /// Lista todas as unidade de medidas e os valores.
        /// </summary>
        /// <returns>Valor Unidades de medidas</returns>
        /// <response code="200">Retorna as unidades de medidas e os valores correspondentes cadastradas</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValorUnidadeMedida>>> ListarRegistros()
        {
            return new ObjectResult(await _repo.BuscarTodos());
        }

        // GET api/v2/ValorUnidadeMedida/{id}
        /// <summary>
        /// Lista uma unidade de medida com seu valor respectivo filtrado por id.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET api/v2/ValorUnidadeMedida/{id}
        ///     {
        ///        "internalId": "string",
        ///        "id": int,
        ///        "unidadeMedida": "string",
        ///        "valor": double
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Unidade de medida localizada</returns>
        /// <response code="200">Retorna o registro encontrado pelo id</response>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ValorUnidadeMedida>> ListarRegistro(long id)
        {
            var todo = await _repo.BuscarId(id);

            if (todo == null)
                return new NotFoundResult();

            return new ObjectResult(todo);
        }

        // POST api/v2/ValorUnidadeMedida
        /// <summary>
        /// Cria uma unidade de medida com seu valor respectivo.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/v2/ValorUnidadeMedida
        ///     {
        ///        "unidadeMedida": "string",
        ///        "valor": double
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Nova unidade de medida criado</returns>
        /// <response code="201">Retorna o novo registro criado</response>
        /// <response code="400">Se o registro não for criado</response>
        [HttpPost]
        public async Task<ActionResult<ValorUnidadeMedida>> Inserir([FromBody] ValorUnidadeMedida todo)
        {
            if (ModelState.IsValid)
            {
                todo.Id = await _repo.IncrementarId();
                await _repo.Incluir(todo);
                return new OkObjectResult(todo);
            }
            else
            {
                return BadRequest();
            }
        }

         // PUT api/v2/ValorUnidadeMedida/{id}
        /// <summary>
        /// Atualiza uma unidade de medida com seu valor respectivo.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT api/v2/ValorUnidadeMedida/{id}
        ///     {
        ///        "unidadeMedida": "string",
        ///        "valor": double
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Atualiza unidade de medida</returns>
        /// <response code="200">Retorna o registro atualizado</response>
        /// <response code="400">Se o registro não for atualizado</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ValorUnidadeMedida>> Atualizar(long id, [FromBody] ValorUnidadeMedida todo)
        {
            var todoFromDb = await _repo.BuscarId(id);

            if (todoFromDb == null)
                return new NotFoundResult();

            todo.Id = todoFromDb.Id;
            todo.InternalId = todoFromDb.InternalId;

            if (ModelState.IsValid)
            {
                await _repo.Atualizar(todo);
                return new OkObjectResult(todo);
            }
            else
            {
                return BadRequest();
            }
                
        }

          // DELETE api/v2/ValorUnidadeMedida/{id}
        /// <summary>
        /// Deleta uma unidade de medida com seu valor respectivo.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     DELETE api/v2/ValorUnidadeMedida/{id}
        ///     {
        ///        "unidadeMedida": "string",
        ///        "valor": double
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Deleta unidade de medida</returns>
        /// <response code="201">Retorna sucess </response>
        /// <response code="400">Erro Se o registro não for deletado</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(long id)
        {
            var post = await _repo.BuscarId(id);

            if (post == null)
                return new NotFoundResult();

            await _repo.Remover(id);

            return new OkResult();
        }
    }
}