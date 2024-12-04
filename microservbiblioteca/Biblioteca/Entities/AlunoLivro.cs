namespace microservbiblioteca.Biblioteca.Entities
{
    public class AlunoLivro
    {
        public Guid Id { get; set; }
        public int? CodigoAluno { get; set; }
        public int? CodigoLivro { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Prazo { get; set; }
    }
}
