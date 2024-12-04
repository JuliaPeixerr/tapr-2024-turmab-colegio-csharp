using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Entities;

namespace microservbiblioteca.Biblioteca.Services.Infrastructure
{
    public interface IAlunoService
    {
        Task<Aluno> GetAll(GetAlunoQuery query);
        Task<Aluno> SaveAsync(SaveAlunoCommand command);
        Task<Aluno> UpdateAsync(string id, SaveAlunoCommand command);
        Task<Aluno> DeleteAsync(string id);
    }
}
