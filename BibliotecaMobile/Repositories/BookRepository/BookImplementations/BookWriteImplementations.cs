using BibliotecaMobile.Helpers;
using BibliotecaMobile.Models;
using BibliotecaMobile.Repositories.BookRepository.IBook.WriteBookRepository;
using Flurl.Http;

namespace BibliotecaMobile.Repositories.BookRepository.BookImplementations
{
    public class BookWriteImplementations : IWriteBookRepository
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
    }
}
