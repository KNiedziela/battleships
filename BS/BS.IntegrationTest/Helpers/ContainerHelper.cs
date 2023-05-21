using BS.Core.Bootstrappers;
using BS.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BS.IntegrationTest.Helpers;

public static class ContainerHelper
{
    public static TService GetService<TService>()
    {
        var services = new ServiceCollection();
        services.RegisterCoreServices();
        services.ReplaceWithSingleton<IBoardRepository, BoardRepository>();

        var provider = services.BuildServiceProvider();

        return provider.GetService<TService>();
    }

    public static IServiceCollection ReplaceWithSingleton<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        var serviceDescriptor = services.SingleOrDefault(descriptor => descriptor.ServiceType == typeof(TService));
        if (serviceDescriptor != null)
        {
            services.Remove(serviceDescriptor);
            services.AddSingleton<TService, TImplementation>();
        }
        else
        {
            throw new InvalidOperationException($"Service of type {typeof(TService)} not found in the service collection.");
        }

        return services;
    }
}