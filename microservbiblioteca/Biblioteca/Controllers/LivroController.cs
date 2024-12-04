using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Entities;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace microservbiblioteca.Biblioteca.Controllers
{
    [ApiController]
    [Route("/api/v1/livro")]
    public class LivroController : ControllerBase
    {
        private ILivroService _service;

        public LivroController(ILivroService service)
            => _service = service;
        
        [HttpGet("get/all")]
        public async Task<IResult> GetAllAsync([FromQuery] GetAllLivrosQuery query)
            => Results.Ok(await this._service.GetAllAsync(query));

        [HttpPost("create")]
        public async Task<IResult> Create([FromBody] SaveLivroCommand command)
            => Results.Ok(await _service.SaveAsync(command));

        [HttpPut("save/{id}")]
        public async Task<IResult> Save(String id, [FromBody] SaveLivroCommand command)
            => Results.Ok(_service.UpdateAsync(id, command));

        [HttpDelete("delete/{id}")]
        public async Task<IResult> Delete(String id)
            => Results.Ok(await _service.DeleteAsync(id));
    }
}
