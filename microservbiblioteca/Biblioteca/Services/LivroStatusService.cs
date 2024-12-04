using microservbiblioteca.Biblioteca.Database;
using microservbiblioteca.Biblioteca.Database.Finder;
using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Entities;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace microservbiblioteca.Biblioteca.Services
{
    public class LivroStatusService : ILivroStatusService
    {
        private RepositoryDbContext _dbContext;

        public LivroStatusService(RepositoryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<List<LivroStatus>> GetAllAsync()
            => await _dbContext.LivroStatus.ToListAsync();

        public async Task<LivroStatus> SaveAsync(SaveLivroStatusCommand command)
        {
            var status = new LivroStatus();
            status.Descricao = command.Descricao;

            await this._dbContext.AddAsync(status);
            await this._dbContext.SaveChangesAsync();

            return status;
        }

        public async Task<LivroStatus> UpdateAsync(String id, SaveLivroStatusCommand command)
        {
            var status = await this._dbContext.LivroStatus.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (status == null) return null;

            status.Descricao = command.Descricao;
            await this._dbContext.SaveChangesAsync();
            return status;
        }

        public async Task<LivroStatus> DeleteAsync(String id)
        {
            var entity = await this._dbContext.LivroStatus.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (entity == null) return null;

            this._dbContext.Remove(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
