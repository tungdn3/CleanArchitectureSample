﻿namespace CleanArchitectureSample.Shared.Abstractions.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : class, IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
