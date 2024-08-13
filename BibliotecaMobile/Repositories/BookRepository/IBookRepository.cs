using BibliotecaMobile.Models;

namespace BibliotecaMobile.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<bool> AddBookASync(Book book);
    }
}
