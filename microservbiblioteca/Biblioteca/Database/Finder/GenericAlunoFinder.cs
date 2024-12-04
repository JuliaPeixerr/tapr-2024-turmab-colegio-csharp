using microservbiblioteca.Biblioteca.Entities;
using System.Linq.Expressions;

namespace microservbiblioteca.Biblioteca.Database.Finder
{
    public class GenericAlunoFinder
    {
        private int? _id;
        private string _nome;
        private string _matricula;

        public GenericAlunoFinder Id(int? id)
        {
            _id = id;
            return this;
        }

        public GenericAlunoFinder Nome(string? nome)
        {
            _nome = nome;
            return this;
        }

        public GenericAlunoFinder Matricula(string? matricula)
        {
            _matricula = matricula;
            return this;
        }

        public Expression<Func<Aluno, bool>> ToExpression()
            => (aluno) => (_id == null || Convert.ToUInt32(aluno.Id) ==  _id) &&
            (_nome == null || aluno.Nome == _nome) &&
            (_matricula == null || aluno.Matricula == _matricula);
    }
}
