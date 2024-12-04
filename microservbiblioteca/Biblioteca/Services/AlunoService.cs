using microservbiblioteca.Biblioteca.Database;
using microservbiblioteca.Biblioteca.Database.Finder;
using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Domain.Query;
using microservbiblioteca.Biblioteca.Entities;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace microservbiblioteca.Biblioteca.Services
{
    public class AlunoService : IAlunoService
    {
        private RepositoryDbContext _dbContext;

        public AlunoService(RepositoryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Aluno> GetAll(GetAlunoQuery query)
        {
            var func = new GenericAlunoFinder()
                .Nome(query.Nome)
                .Matricula(query.Matricula)
                .ToExpression();
            
            var aluno = await this._dbContext.Aluno.Where(func)
                .FirstOrDefaultAsync();

            return aluno;
        }

        // emitir carteirinha
        public async Task<Aluno> SaveAsync(SaveAlunoCommand command)
        {
            var aluno = new Aluno();
            aluno.Nome = command.Nome;
            aluno.Matricula = command.Matricula;

            await this._dbContext.AddAsync(aluno);
            await this._dbContext.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> UpdateAsync(String id, SaveAlunoCommand command)
        {
            var aluno = await this._dbContext.Aluno.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (aluno == null) return null;

            aluno.Nome = command.Nome;
            aluno.Matricula = command.Matricula;

            await this._dbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> DeleteAsync(String id)
        {
            var entity = await this._dbContext.Aluno.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (entity == null) return null;

            this._dbContext.Remove(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
