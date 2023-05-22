using Microsoft.Extensions.Logging;
using Noted.Services;

namespace Noted;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<NotesViewModel>();

        builder.Services.AddSingleton<NotesService>();

        builder.Services.AddSingleton<Views.MainPage>();

        builder.Services.AddTransient<DetailViewModel>();
        builder.Services.AddTransient<Views.DetailsPage>();

        return builder.Build();
    }
}
