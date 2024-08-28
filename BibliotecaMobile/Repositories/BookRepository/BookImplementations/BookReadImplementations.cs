using BibliotecaMobile.Helpers;
using BibliotecaMobile.Models;
using BibliotecaMobile.Repositories.BookRepository.IBook.ReadBookRepository;
using Flurl.Http;

namespace BibliotecaMobile.Repositories.BookRepository.BookImplementations
{
    public class BookReadImplementations : IReadBookRepository
    {
        public async Task<List<Book>> GetAllAsync()
        {
            List<Book> _books = new List<Book>();
           
            var dados = await Constants.urlAPI
                                 .GetJsonAsync<List<Book>>();

                for (int i = 0; i < dados.Count; i++)
                {
                    Book livro = new Book(dados[i].Titulo, dados[i].Autor, dados[i].Isbn, dados[i].AnoPublicacao, dados[i].StatusBook);
                    _books.Add(livro);
                }     
            

            return _books;

        }
    }
}
