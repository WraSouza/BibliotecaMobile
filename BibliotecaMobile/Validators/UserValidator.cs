using BibliotecaMobile.Models;
using Flunt.Validations;

namespace BibliotecaMobile.Validators
{
    public class UserValidator : Contract<User>
    {
        public UserValidator(User user)
        {
            Requires()
                .IsNotEmpty(user.Nome, nameof(user.Nome),"O Nome Deve Ser Preenchido");

            Requires()
                .IsNotEmpty(user.Email, nameof(user.Email), "o Email Deve Ser Preenchido");

            Requires()
                .IsEmail(user.Email, nameof(user.Email), "Email Inválido");
        }
    }
}
