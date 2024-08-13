using BibliotecaMobile.Models;
using Flunt.Validations;

namespace BibliotecaMobile.Validators
{
    public class BookValidators : Contract<Book>
    {
        public BookValidators(Book book)
        {
            //Título
            Requires().
                IsNotEmpty(book.Titulo, nameof(book.Titulo), "Título do Livro é Obrigatório");

            Requires()
                .IsGreaterThan(book.Titulo,200, nameof(book.Titulo), "O Título Deve Ter no Máximo 200 Caracteres");


            //Autor
            Requires()
                .IsNotNullOrEmpty(book.Autor, nameof(book.Autor), "O Campo Autor é Obrigatório");

            //ISBN
            Requires()
                .IsNotNullOrEmpty(book.Isbn, nameof(book.Isbn), "O ISBN do Livro é Obrigatório");

            //Ano de Publicação
            Requires()
               .IsNotNullOrEmpty(book.AnoPublicacao.ToString(), nameof(book.AnoPublicacao), "O Ano de Publicação é Obrigatório");

            
        }
    }
}
