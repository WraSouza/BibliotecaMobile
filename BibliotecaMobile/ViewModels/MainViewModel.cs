using BibliotecaMobile.Models;
using BibliotecaMobile.Repositories.BookRepository;

namespace BibliotecaMobile.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Book> Books { get; set; }
        = new ObservableCollection<Book>();

    private readonly IBookRepository _bookRepository;
    
    public MainViewModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;       

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

        var newBooks = await _bookRepository.GetAllAsync();

        foreach (var book in newBooks)
        {
            if(int.Parse(book.StatusBook) == 0)
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
    }

    [RelayCommand]
    public async Task GotoInsertBook()
        => await Shell.Current.GoToAsync(nameof(InsertBookView));
}
