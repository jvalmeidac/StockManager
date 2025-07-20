using Microsoft.Extensions.DependencyInjection;
using StockManager.SharedKernel.Dispatcher.Interfaces;

namespace StockManager.SharedKernel.Dispatcher;

public interface IDispatcher
{
    Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    Task<TResult> SendCommandAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
}

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public async Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        var handler = serviceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"Handler not found for {command.GetType().Name}");

        var method = handlerType.GetMethod(nameof(ICommandHandler<TCommand>.HandleAsync));
        await (Task)method?.Invoke(handler, [command])!;
    }

    public async Task<TResult> SendCommandAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
        var handler = serviceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"Handler not found for {command.GetType().Name}");

        var method = handlerType.GetMethod(nameof(ICommandHandler<TCommand, TResult>.HandleAsync));
        return await (Task<TResult>)method?.Invoke(handler, [command])!;
    }

    public async Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

        var handler = serviceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"Handler not found for {query.GetType().Name}");

        var method = handlerType.GetMethod(nameof(IQueryHandler<TQuery, TResult>.HandleAsync));
        return await (Task<TResult>)method?.Invoke(handler, [query])!;
    }
}

public static class DispatcherExtensions
{
    public static async Task SendCommandAsync(this IDispatcher dispatcher, ICommand query)
    {
        await dispatcher.SendCommandAsync<ICommand>(query);
    }
    
    public static async Task<TResult> SendCommandAsync<TResult>(this IDispatcher dispatcher, ICommand<TResult> query)
    {
        return await dispatcher.SendCommandAsync<ICommand<TResult>, TResult>(query);
    }
    
    public static async Task<TResult> SendQueryAsync<TResult>(this IDispatcher dispatcher, IQuery<TResult> query)
    {
        return await dispatcher.SendQueryAsync<IQuery<TResult>, TResult>(query);
    }
}