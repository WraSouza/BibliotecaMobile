using BibliotecaMobile.Models;
using BibliotecaMobile.Repositories.UserRepository;
using BibliotecaMobile.Validators;
using CommunityToolkit.Maui.Alerts;
using System.Text;

namespace BibliotecaMobile.ViewModels
{
    public partial class UsersViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        public ObservableCollection<User> Usuarios { get; set; }
        = new ObservableCollection<User>();

        public UsersViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [ObservableProperty]
        string nome;

        [ObservableProperty]
        string email;

        [RelayCommand]
        public async Task InsertUser()
        {
            var usuario = new User(Nome, Email);

            var validator = new UserValidator(usuario);

            if (!validator.IsValid)
            {
                var messages = validator.Notifications.Select(x => x.Message);

                var sb = new StringBuilder();

                foreach (var message in messages)
                {
                    sb.AppendLine($"{message}\n");

                    await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");

                    return;
                }
            }

            bool result = await _userRepository.AddUserASync(usuario);

            if (!result)
            {
                var toast = Toast.Make("Falha Ao Cadastrar Usuário, Tente Novamente", CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();

                return;
            }

            var newtoast = Toast.Make("Usuário Cadastrado Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

            await newtoast.Show();

            await Shell.Current.GoToAsync("..");
        }

        private void GetUsers()
        {

        }

        [RelayCommand]
        public async Task GotoInsertUser()
       => await Shell.Current.GoToAsync(nameof(InsertUserView));
    }
}
