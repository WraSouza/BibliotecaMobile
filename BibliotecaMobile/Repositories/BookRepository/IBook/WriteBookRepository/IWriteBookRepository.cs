using BibliotecaMobile.Models;

namespace BibliotecaMobile.Repositories.BookRepository.IBook.WriteBookRepository
{
    interface IWriteBookRepository
    {
        Task<bool> AddBookASync(Book book);
    }
}
