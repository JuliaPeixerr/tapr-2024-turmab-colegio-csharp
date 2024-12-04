using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Entities;

namespace microservbiblioteca.Biblioteca.Services.Infrastructure
{
    public interface ILivroStatusService
    {
        Task<List<LivroStatus>> GetAllAsync();
        Task<LivroStatus> SaveAsync(SaveLivroStatusCommand command);
        Task<LivroStatus> UpdateAsync(String id, SaveLivroStatusCommand command);
        Task<LivroStatus> DeleteAsync(String id);
    }
}
