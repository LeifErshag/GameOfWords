using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;

namespace GameOfWords;

public static class ServiceHelper
{
    public static TService GetService<TService>() where TService : notnull
        => Current.GetService<TService>() ?? throw new InvalidOperationException("Service not found");

    public static IServiceProvider Current => Application.Current?.Handler?.MauiContext?.Services
        ?? throw new InvalidOperationException("MauiContext not initialized");
}
