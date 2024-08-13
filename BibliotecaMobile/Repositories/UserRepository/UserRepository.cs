using BibliotecaMobile.Models;
using BibliotecaMobile.Helpers;
using Flurl.Http;

namespace BibliotecaMobile.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> AddUserASync(User model)
        {
            try
            {
                var dados = await Constants.urlAPIUser
               .PostJsonAsync(model);

                return dados.ResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("", ex.Message, "OK");
            }

            return false;
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
