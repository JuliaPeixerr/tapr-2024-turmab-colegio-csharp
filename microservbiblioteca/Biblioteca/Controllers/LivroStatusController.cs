using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace microservbiblioteca.Biblioteca.Controllers
{
    [ApiController]
    [Route("/api/v1/livroStatus")]
    public class LivroStatusController : ControllerBase
    {
        private ILivroStatusService _service;

        public LivroStatusController(ILivroStatusService service)
            => _service = service;

        [HttpGet("get/all")]
        public async Task<IResult> GetAllAsync()
            => Results.Ok(await this._service.GetAllAsync());

        [HttpPost("create")]
        public async Task<IResult> Create([FromBody] SaveLivroStatusCommand command)
            => Results.Ok(await _service.SaveAsync(command));

        [HttpPut("save/{id}")]
        public async Task<IResult> Save(String id, [FromBody] SaveLivroStatusCommand command)
            => Results.Ok(_service.UpdateAsync(id, command));

        [HttpDelete("delete/{id}")]
        public async Task<IResult> Delete(String id)
            => Results.Ok(await _service.DeleteAsync(id));
    }
}
