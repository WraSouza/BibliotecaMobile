using BibliotecaMobile.Models;
using BibliotecaMobile.Repositories.BookRepository;
using BibliotecaMobile.Validators;
using CommunityToolkit.Maui.Alerts;
using System.Text;

namespace BibliotecaMobile.ViewModels
{
    public partial class InsertBookViewModel : ObservableObject
    {
        private readonly IBookRepository _bookRepository;
        public InsertBookViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            //ResetarCampos();
            Anopublicacao = null;

            Titulo = null;

            Autor = null;

            Isbn = null;

        }

        [ObservableProperty]
        string? titulo;

        [ObservableProperty]
        string? autor;

        [ObservableProperty]
        string? isbn;

        [ObservableProperty]
        int? anopublicacao;        
      

        [RelayCommand]
        public async Task InsertBook()
        {
            var book = new Book(titulo, autor, isbn, anopublicacao);

            var validator = new BookValidators(book);

            if(!validator.IsValid)
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

            bool result = await _bookRepository.AddBookASync(book);

            if (!result)
            {
                var toast = Toast.Make("Falha Ao Cadastrar Livro, Tente Novamente", CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();

                return;
            }

            var newtoast = Toast.Make("Livro Cadastrado Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

            await newtoast.Show();

            await Shell.Current.GoToAsync("..");
        }
        
    }
}
