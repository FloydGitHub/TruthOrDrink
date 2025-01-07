using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TruthOrDrink.DatabaseInfo;

namespace TruthOrDrink
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<GameRepository>();
            builder.Services.AddSingleton<QuestionRepository>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
