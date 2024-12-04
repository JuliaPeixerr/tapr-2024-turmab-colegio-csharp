using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Entities;

namespace microservbiblioteca.Biblioteca.Services.Infrastructure
{
    public interface ILivroTemaService
    {
        Task<List<LivroTema>> GetAllAsync();
        Task<LivroTema> SaveAsync(SaveLivroTemaCommand command);
        Task<LivroTema> UpdateAsync(String id, SaveLivroTemaCommand command);
        Task<LivroTema> DeleteAsync(String id);
    }
}
