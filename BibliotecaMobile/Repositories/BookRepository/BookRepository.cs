using BibliotecaMobile.Helpers;
using BibliotecaMobile.Models;
using Flurl.Http;

namespace BibliotecaMobile.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        public async Task<bool> AddBookASync(Book book)
        {
            try
            {
                var dados = await Constants.urlAPI
               .PostJsonAsync(book);

                return dados.ResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("", ex.Message, "OK");
            }

            return false;
        }

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
