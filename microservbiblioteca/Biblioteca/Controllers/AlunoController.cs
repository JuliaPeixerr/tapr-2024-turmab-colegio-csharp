using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace microservbiblioteca.Biblioteca.Controllers
{
    [ApiController]
    [Route("/api/v1/aluno")]
    public class AlunoController : ControllerBase
    {
        private IAlunoService _service;

        public AlunoController(IAlunoService service)
            => _service = service;

        [HttpGet("get/all")]
        public async Task<IResult> GetAll([FromQuery] GetAlunoQuery query)
            => Results.Ok(await this._service.GetAll(query));

        [HttpPost("create")]
        public async Task<IResult> Create([FromBody] SaveAlunoCommand command)
            => Results.Ok(await _service.SaveAsync(command));

        [HttpPut("save/{id}")]
        public async Task<IResult> Save(String id, [FromBody] SaveAlunoCommand command)
            => Results.Ok(_service.UpdateAsync(id, command));

        [HttpDelete("delete/{id}")]
        public async Task<IResult> Delete(String id)
            => Results.Ok(await _service.DeleteAsync(id));
    }
}
