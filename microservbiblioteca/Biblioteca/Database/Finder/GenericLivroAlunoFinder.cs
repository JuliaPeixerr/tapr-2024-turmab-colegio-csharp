using microservbiblioteca.Biblioteca.Entities;
using System.Linq.Expressions;

namespace microservbiblioteca.Biblioteca.Database.Finder
{
    public class GenericLivroAlunoFinder
    {
        private int? _codigoAluno;

        public GenericLivroAlunoFinder CodigoAluno(int? codigoAluno)
        {
            _codigoAluno = codigoAluno;
            return this;
        }

        public Expression<Func<AlunoLivro, bool>> ToExpression()
            => (alunoLivro) => (_codigoAluno == null || alunoLivro.CodigoAluno == _codigoAluno);
    }
}
