using Microsoft.Extensions.DependencyInjection;
using StockManager.Data.DbContext;
using StockManager.Dominio.Repositories.Base;

namespace StockManager.Data;

public static class IoC
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddSingleton<StockManagerDbContext>();
        
        services.Scan(scan => scan
            .FromAssemblyOf<AssemblyHelper>()
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}

public class AssemblyHelper {}