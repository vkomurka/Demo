using Microsoft.EntityFrameworkCore;

namespace Demo.DesktopClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<Desktop.Model.Context>();

            builder.Services.AddTransient<MainPage>();

            var connectionString = "Filename=\"" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DemoClient.db\"");
            builder.Services.AddDbContext<Desktop.Model.Context>(options =>
            {
                options.UseSqlite(connectionString);
            });

            return builder.Build();
        }
    }
}