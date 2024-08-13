namespace BibliotecaMobile.Views;

public partial class UsersView : ContentPage
{
    private readonly UsersViewModel _viewModel;
    public UsersView(UsersViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}