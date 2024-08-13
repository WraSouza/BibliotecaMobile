namespace BibliotecaMobile.Models
{
    public class Book
    {
        public Book(string? titulo, string? autor, string? isbn, int? anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
        }

        public string? Titulo { get; private set; }
        public string? Autor { get; private set; }
        public string? Isbn { get; private set; }
        public int? AnoPublicacao { get; private set; }
    }
}
