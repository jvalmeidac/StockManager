using Microsoft.Extensions.DependencyInjection;
using StockManager.SharedKernel.Dispatcher;

namespace StockManager.SharedKernel;

public static class IoC
{
    public static void RegisterSharedKernel(this IServiceCollection services)
    {
        services.AddSingleton<IDispatcher, Dispatcher.Dispatcher>();
    }
}