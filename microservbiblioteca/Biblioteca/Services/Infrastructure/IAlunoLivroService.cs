using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Entities;

namespace microservbiblioteca.Biblioteca.Services.Infrastructure
{
    public interface IAlunoLivroService
    {
        Task<List<AlunoLivro>> GetAllByAluno(String id);
        Task<AlunoLivro> SaveAsync(SaveAlunoLivroCommand command);
        Task<AlunoLivro> DeleteAsync(String id);
        Task<double> CalcularMultaByAluno(String id);
    }
}
