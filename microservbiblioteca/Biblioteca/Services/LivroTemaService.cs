using microservbiblioteca.Biblioteca.Database;
using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Entities;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace microservbiblioteca.Biblioteca.Services
{
    public class LivroTemaService : ILivroTemaService
    {
        private RepositoryDbContext _dbContext;

        public LivroTemaService(RepositoryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<List<LivroTema>> GetAllAsync()
            => await _dbContext.LivroTema.ToListAsync();

        public async Task<LivroTema> SaveAsync(SaveLivroTemaCommand command)
        {
            var tema = new LivroTema();
            tema.Descricao = command.Descricao;

            await this._dbContext.AddAsync(tema);
            await this._dbContext.SaveChangesAsync();

            return tema;
        }

        public async Task<LivroTema> UpdateAsync(String id, SaveLivroTemaCommand command)
        {
            var tema = await this._dbContext.LivroTema.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (tema == null) return null;

            tema.Descricao = command.Descricao;
            await this._dbContext.SaveChangesAsync();
            return tema;
        }

        public async Task<LivroTema> DeleteAsync(String id)
        {
            var entity = await this._dbContext.LivroTema.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (entity == null) return null;

            this._dbContext.Remove(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
