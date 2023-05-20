using BS.Core.Repositories;
using BS.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BS.Core.Bootstrappers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IBoardGenerationService, BoardGenerationService>();
        services.AddTransient<IGameplayService, GameplayService>();
        services.AddTransient<IShipFactory, ShipFactory>();
        services.AddSingleton<IBoardRepository, BoardRepository>();

        return services;
    }
}