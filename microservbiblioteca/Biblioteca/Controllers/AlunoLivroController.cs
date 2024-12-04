using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace microservbiblioteca.Biblioteca.Controllers
{
    [ApiController]
    [Route("/api/v1/alunoLivro")]
    public class AlunoLivroController : ControllerBase
    {
        private IAlunoLivroService _service;

        public AlunoLivroController(IAlunoLivroService service)
            => _service = service;

        [HttpGet("get/all/by-aluno/{id}")]
        public async Task<IResult> GetAllByAluno(String id)
            => Results.Ok(await this._service.GetAllByAluno(id));

        [HttpPost("create")]
        public async Task<IResult> Create([FromBody] SaveAlunoLivroCommand command)
            => Results.Ok(await _service.SaveAsync(command));

        [HttpDelete("delete/{id}")]
        public async Task<IResult> Delete(String id)
            => Results.Ok(await _service.DeleteAsync(id));

        [HttpPost("calcular/multa/by-aluno/{id}")]
        public async Task<IResult> CalcularMultaByAluno(String id)
            => Results.Ok(await this._service.CalcularMultaByAluno(id));
    }
}
