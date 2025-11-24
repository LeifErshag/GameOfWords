using GameOfWords.Services;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;

namespace GameOfWords;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        builder.Services.AddSingleton<IGameStateService, GameStateService>();
        builder.Services.AddSingleton<IGameLoop, GameLoop>();

        return builder.Build();
    }
}
