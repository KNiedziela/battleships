using BS.ConsoleApp.Services;
using BS.Core.Bootstrappers;
using Microsoft.Extensions.DependencyInjection;

namespace BS.ConsoleApp.Bootstrappers;

public static class ContainerHelper
{
    public static TService GetService<TService>()
    {
        var services = new ServiceCollection();
        services.RegisterCoreServices();
        services.AddTransient<IConsoleGameService, ConsoleGameService>();
        services.AddTransient<IDrawingService, DrawingService>();

        var provider = services.BuildServiceProvider();

        return provider.GetService<TService>();
    }
}