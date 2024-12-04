namespace microservbiblioteca.Biblioteca.Domain.Query
{
    public class GetAllLivrosQuery
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Autor { get; set; }
        public int? CodigoTema { get; set; }
        public int? CodigoStatus { get; set; }
    }
}
