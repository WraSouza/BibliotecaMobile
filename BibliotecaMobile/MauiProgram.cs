using BibliotecaMobile.Repositories.BookRepository;
using BibliotecaMobile.Repositories.BookRepository.BookImplementations;
using BibliotecaMobile.Repositories.BookRepository.IBook.ReadBookRepository;
using BibliotecaMobile.Repositories.UserRepository;


namespace BibliotecaMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()            
			.UseMauiCommunityToolkit()
            .UseSentry(options =>
            {               
                options.Dsn = "https://c0e90ef8153366738c28041b6a92fa41@o4505269022752768.ingest.us.sentry.io/4507981108477952";
                
                options.Debug = true;
               
                options.TracesSampleRate = 1.0;
                
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemibold");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
            });

		builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<UsersViewModel>();
        builder.Services.AddSingleton<InsertBookViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<UsersView>();
        builder.Services.AddSingleton<InsertUserView>();
        builder.Services.AddSingleton<InsertBookView>();

		builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IReadBookRepository, BookReadImplementations>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        return builder.Build();
	}
}
