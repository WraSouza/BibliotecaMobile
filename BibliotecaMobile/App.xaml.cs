namespace BibliotecaMobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        Routing.RegisterRoute(nameof(InsertBookView), typeof(InsertBookView));
        Routing.RegisterRoute(nameof(InsertUserView), typeof(InsertUserView));
        Routing.RegisterRoute(nameof(UsersView), typeof(UsersView));
    }
}
