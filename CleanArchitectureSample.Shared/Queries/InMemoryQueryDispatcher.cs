﻿using CleanArchitectureSample.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureSample.Shared.Queries
{
    public class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Dispatch<TResult>(IQuery<TResult> query)
        {
            using var scope = _serviceProvider.CreateScope();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);
            return await (Task<TResult>)handlerType.GetMethod("Handle")?.Invoke(handler, new[] { query });
        }
    }
}
