using microservbiblioteca.Biblioteca.Database;
using microservbiblioteca.Biblioteca.Database.Finder;
using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Entities;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace microservbiblioteca.Biblioteca.Services
{
    public class LivroService : ILivroService
    {
        private RepositoryDbContext _dbContext;

        public LivroService(RepositoryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<List<Livro>> GetAllAsync(GetAllLivrosQuery query)
        {
            var func = new GenericLivroFinder()
                .Nome(query.Nome)
                .Descricao(query.Descricao)
                .Autor(query.Autor)
                .CodigoStatus(query.CodigoStatus)
                .CodigoTema(query.CodigoTema)
                .ToExpression();

            var livro = await this._dbContext.Livro.Where(func)
                .ToListAsync();

            return livro;
        }

        public async Task<Livro> SaveAsync(SaveLivroCommand command)
        {
            var livro = new Livro();
            livro.Nome = command.Nome;
            livro.Descricao = command.Descricao;
            livro.Autor = command.Autor;
            livro.CodigoTema = command.CodigoTema;
            //livro.CodigoStatus = ENUM;

            await this._dbContext.AddAsync(livro);
            await this._dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<Livro> UpdateAsync(String id, SaveLivroCommand command)
        {
            var livro = await this._dbContext.Livro.Where(a => 
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (livro == null) return null;

            livro.Nome = command.Nome;
            livro.Descricao = command.Descricao;
            livro.Autor = command.Autor;
            livro.CodigoTema = command.CodigoTema;
            livro.CodigoStatus = command.CodigoStatus;

            await this._dbContext.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro> DeleteAsync(String id)
        {
            var entity = await this._dbContext.Livro.Where(a => 
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (entity == null) return null;

            this._dbContext.Remove(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
