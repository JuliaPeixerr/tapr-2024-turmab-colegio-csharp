namespace microservbiblioteca.Biblioteca.Domain.Command
{
    public class SaveLivroCommand
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Autor { get; set; }
        public int? CodigoTema { get; set; }
        public int? CodigoStatus { get; set; }
    }
}
