using Microsoft.Extensions.DependencyInjection;
using StockManager.SharedKernel.Dispatcher.Interfaces;

namespace StockManager.Application;

public static class IoC
{
    public static void RegisterHandlers(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<AssemblyHelper>()
            .AddClasses(c => c.Where(type =>
                type.GetInterfaces().Any(i =>
                    i.IsGenericType && (
                        i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>) ||
                        i.GetGenericTypeDefinition() == typeof(ICommandHandler<>) ||
                        i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)
                    )
                )))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}

public class AssemblyHelper
{
}