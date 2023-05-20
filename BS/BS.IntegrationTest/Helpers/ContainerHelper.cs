using BS.Core.Bootstrappers;
using Microsoft.Extensions.DependencyInjection;

namespace BS.IntegrationTest.Helpers;

public static class ContainerHelper
{
    public static TService GetService<TService>()
    {
        var services = new ServiceCollection();
        services.RegisterCoreServices();
        var provider = services.BuildServiceProvider();

        return provider.GetService<TService>();
    }
    
}