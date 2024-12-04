using microservbiblioteca.Biblioteca.Entities;
using System.Linq.Expressions;

namespace microservbiblioteca.Biblioteca.Database.Finder
{
    public class GenericLivroFinder
    {
        private int? _id;
        private string? _nome;
        private string? _descricao;
        private string? _autor;
        private int? _codigoStatus;
        private int? _codigoTema;

        public GenericLivroFinder Id(int? id)
        {
            _id = id;
            return this;
        }

        public GenericLivroFinder Nome(string? nome)
        {
            _nome = nome;
            return this;
        }

        public GenericLivroFinder Descricao(string? descricao)
        {
            _descricao = descricao;
            return this;
        }

        public GenericLivroFinder Autor(string? autor)
        {
            _autor = autor;
            return this;
        }

        public GenericLivroFinder CodigoStatus(int? codigoStatus)
        {
            _codigoStatus = codigoStatus;
            return this;
        }

        public GenericLivroFinder CodigoTema(int? codigoTema)
        {
            _codigoTema = codigoTema;
            return this;
        }

        public Expression<Func<Livro, bool>> ToExpression()
            => (livro) => (_id == null || Convert.ToUInt32(livro.Id) == _id) &&
            (_nome == null || livro.Nome == _nome) &&
            (_descricao == null || livro.Descricao == _descricao) &&
            (_autor == null || livro.Autor == _autor) &&
            (_codigoStatus == null || livro.CodigoStatus == _codigoStatus) &&
            (_codigoTema == null || livro.CodigoTema == _codigoTema);
    }
}
