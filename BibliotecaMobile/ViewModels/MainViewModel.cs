using BibliotecaMobile.Helpers;
using BibliotecaMobile.Models;
using BibliotecaMobile.Repositories.BookRepository;
using BibliotecaMobile.Repositories.BookRepository.IBook.ReadBookRepository;

namespace BibliotecaMobile.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Book> Books { get; set; }
        = new ObservableCollection<Book>();

    private readonly IBookRepository _bookRepository;
    private readonly IReadBookRepository _readBookRepository;

    public MainViewModel(IBookRepository bookRepository, IReadBookRepository readBookRepository)
    {
        _bookRepository = bookRepository;

        _readBookRepository = readBookRepository;

        BuscaLivros();
    }

    [RelayCommand]
    public async Task UpdateView()
    {
        await BuscaLivros();
    }

    private async Task BuscaLivros()
    {
        IsBusy = true;

        Books.Clear();

        var hasConnection = Conectividade.GetConnectivity();

        if (hasConnection)
        {
            var newBooks = await _readBookRepository.GetAllAsync();

            foreach (var book in newBooks)
            {
                if (book.StatusBook == "0")
                {
                    var newBook = new Book(book.Titulo, book.Autor, book.Isbn, book.AnoPublicacao, "Disponível");

                    Books.Add(newBook);
                }
                else
                {
                    var newBook = new Book(book.Titulo, book.Autor, book.Isbn, book.AnoPublicacao, "Indisponível");

                    Books.Add(newBook);
                }
                //Books.Add(book);
            }

            IsBusy = false;

            return;
        }          

        await Shell.Current.DisplayAlert("", "Não Foi Possível Buscar Dados. Verifique Sua Conexão Com a Internet", "OK");
       
    }

    [RelayCommand]
    public async Task GotoInsertBook()
        => await Shell.Current.GoToAsync(nameof(InsertBookView));
}
