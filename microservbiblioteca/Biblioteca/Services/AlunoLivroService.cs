using microservbiblioteca.Biblioteca.Database;
using microservbiblioteca.Biblioteca.Database.Finder;
using microservbiblioteca.Biblioteca.Domain.Command;
using microservbiblioteca.Biblioteca.Entities;
using microservbiblioteca.Biblioteca.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace microservbiblioteca.Biblioteca.Services
{
    public class AlunoLivroService : IAlunoLivroService
    {
        private RepositoryDbContext _dbContext;

        public AlunoLivroService(RepositoryDbContext dbContext)
            => _dbContext = dbContext;

        // get all que estao em emprestimo por aluno
        public async Task<List<AlunoLivro>> GetAllByAluno(String id)
        {
            var func = new GenericLivroAlunoFinder()
                .CodigoAluno(Convert.ToInt32(id))
                .ToExpression();

            var livro = await this._dbContext.AlunoLivro.Where(func)
                .ToListAsync();

            return livro;
        }

        // vincular um livro ao aluno
        public async Task<AlunoLivro> SaveAsync(SaveAlunoLivroCommand command)
        {
            var alunoLivro = new AlunoLivro();
            alunoLivro.CodigoAluno = command.CodigoAluno;
            alunoLivro.CodigoLivro = command.CodigoLivro;
            alunoLivro.Data = DateTime.Now;
            // 2 semanas de prazo
            alunoLivro.Prazo = DateTime.Now.AddDays(14);

            await this._dbContext.AddAsync(alunoLivro);
            await this._dbContext.SaveChangesAsync();

            return alunoLivro;
        }

        // devolução do livro
        public async Task<AlunoLivro> DeleteAsync(String id)
        {
            var entity = await this._dbContext.AlunoLivro.Where(a =>
                a.Id.Equals(new Guid(id))).FirstOrDefaultAsync();

            if (entity == null) return null;

            this._dbContext.Remove(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<double> CalcularMultaByAluno(String id)
        {
            List<AlunoLivro> listForaDoPrazo = new List<AlunoLivro>();
            
            // todos os livros referentes a este aluno
            var func = new GenericLivroAlunoFinder()
                .CodigoAluno(Convert.ToInt32(id))
                .ToExpression();

            var livros = await this._dbContext.AlunoLivro.Where(func)
                .ToListAsync();

            // verificar quais deles passam do prazo
            listForaDoPrazo.AddRange(livros.Where(l => 
                l.Prazo.HasValue && l.Prazo.Value > DateTime.Now));

            // para cada um que passar eu somo 10 reias
            double valorMulta = 0;
            for (int i = 1; i < listForaDoPrazo.Count; i++)
            {
                valorMulta += 10.00;
            }

            return valorMulta;
        }
    }
}
