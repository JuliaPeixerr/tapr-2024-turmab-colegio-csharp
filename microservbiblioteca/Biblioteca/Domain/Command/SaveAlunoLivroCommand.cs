namespace microservbiblioteca.Biblioteca.Domain.Command
{
    public class SaveAlunoLivroCommand
    {
        public int? CodigoAluno { get; set; }
        public int? CodigoLivro { get; set; }
    }
}
