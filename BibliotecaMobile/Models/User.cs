namespace BibliotecaMobile.Models
{
    public class User
    {
        public User(string? nome, string? email)
        {
            Nome = nome;
            Email = email;
        }

        public string? Nome { get; private set; }
        public string? Email { get; private set; }       
    }
}
