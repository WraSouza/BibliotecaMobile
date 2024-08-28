using BibliotecaMobile.Models;

namespace BibliotecaMobile.Repositories.BookRepository.IBook.ReadBookRepository
{
    public interface IReadBookRepository
    {
        Task<List<Book>> GetAllAsync();
    }
}
