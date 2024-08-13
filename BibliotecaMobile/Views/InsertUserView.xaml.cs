namespace BibliotecaMobile.Views;

public partial class InsertUserView : ContentPage
{
    private readonly UsersViewModel _viewModel;
    public InsertUserView(UsersViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }
}