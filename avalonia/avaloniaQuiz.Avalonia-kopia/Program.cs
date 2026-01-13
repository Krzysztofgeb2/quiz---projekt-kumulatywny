using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using avaloniaQuiz.Data;

namespace avaloniaQuiz;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Tworzymy bazę i seedujemy quizy
        var context = new QuizDbContext();
        await context.Database.EnsureCreatedAsync();
        await Seeder.SeedAsync(context);

        // Uruchomienie aplikacji Avalonia
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}