using System.ComponentModel.DataAnnotations;

namespace microservbiblioteca.Biblioteca.Entities
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Autor { get; set; }
        public int? CodigoStatus { get; set; }
        public int? CodigoTema { get; set; }
    }
}
