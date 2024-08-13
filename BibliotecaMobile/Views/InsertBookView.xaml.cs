namespace BibliotecaMobile.Views;

public partial class InsertBookView : ContentPage
{
    private readonly InsertBookViewModel _viewModel;

    public InsertBookView(InsertBookViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;

    }
}