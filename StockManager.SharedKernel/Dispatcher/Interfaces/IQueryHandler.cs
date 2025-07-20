﻿namespace StockManager.SharedKernel.Dispatcher.Interfaces;

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}