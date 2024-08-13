using BibliotecaMobile.Models;

namespace BibliotecaMobile.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<bool> AddUserASync(User book);
    }
}
