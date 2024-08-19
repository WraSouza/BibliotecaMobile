namespace BibliotecaMobile.Models
{
    public class Book
    {
        public Book(string? titulo, string? autor, string? isbn, int? anoPublicacao, string? statusBook)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
            StatusBook = statusBook;
        }

        public string? Titulo { get; private set; }
        public string? Autor { get; private set; }
        public string? Isbn { get; private set; }
        public int? AnoPublicacao { get; private set; }
        public string? StatusBook { get; private set; }
    }
}
