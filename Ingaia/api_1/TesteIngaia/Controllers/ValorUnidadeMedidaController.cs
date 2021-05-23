using TesteIngaia.Entity;
using TesteIngaia.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TesteIngaia.Controllers
{

    [Produces("application/json")]
    [Route("api/v1/ValorUnidadeMedida")]
    [ApiController]
    public class ValorUnidadeMedidaController : ControllerBase
    {
        private readonly IValorUnidadeMedidaRepository _repo;
     
        public ValorUnidadeMedidaController(IValorUnidadeMedidaRepository repository)
        {
            _repo = repository;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValorUnidadeMedida>>> Get()
        {
            return new ObjectResult(await _repo.GetAllTodos());
        }

        // GET api/todos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ValorUnidadeMedida>> Get(long id)
        {
            var todo = await _repo.GetTodo(id);

            if (todo == null)
                return new NotFoundResult();

            return new ObjectResult(todo);
        }

        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<ValorUnidadeMedida>> Post([FromBody] ValorUnidadeMedida todo)
        {
            todo.Id = await _repo.GetNextId();
            await _repo.Create(todo);
            return new OkObjectResult(todo);
        }

        // PUT api/todos/1
        [HttpPut("{id}")]
        public async Task<ActionResult<ValorUnidadeMedida>> Put(long id, [FromBody] ValorUnidadeMedida todo)
        {
            var todoFromDb = await _repo.GetTodo(id);

            if (todoFromDb == null)
                return new NotFoundResult();

            todo.Id = todoFromDb.Id;
            todo.InternalId = todoFromDb.InternalId;

            await _repo.Update(todo);

            return new OkObjectResult(todo);
        }

        // DELETE api/todos/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetTodo(id);

            if (post == null)
                return new NotFoundResult();

            await _repo.Delete(id);

            return new OkResult();
        }
    }
}