using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Entities;

namespace microservbiblioteca.Biblioteca.Services.Infrastructure
{
    public interface ILivroService
    {
        Task<List<Livro>> GetAllAsync(GetAllLivrosQuery query);
        Task<Livro> SaveAsync(SaveLivroCommand livro);
        Task<Livro> UpdateAsync(string id, SaveLivroCommand livro);
        Task<Livro> DeleteAsync(string id);
    }
}
