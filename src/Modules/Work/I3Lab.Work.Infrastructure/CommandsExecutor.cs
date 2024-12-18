﻿using I3Lab.Treatments.Application.Contract;
using MediatR;
using I3Lab.BuildingBlocks.Infrastructure;

namespace I3Lab.Treatments.Infrastructure
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {
            var mediator = ServiceFactory.GetScopedService<IMediator>();
            await mediator.Send(command);
        }

        internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            var mediator = ServiceFactory.GetScopedService<IMediator>();
            return await mediator.Send(command);
        }
    }




    //internal static class CommandsExecutor
    //{
    //    private static IServiceProvider _serviceProvider;

    //    public static void SetServiceProvider(IServiceProvider serviceProvider)
    //    {
    //        _serviceProvider = serviceProvider;
    //    }

    //    // Метод для выполнения команды без результата
    //    internal static async Task Execute(ICommand command)
    //    {
    //        using var scope = _serviceProvider.CreateScope();
    //        var mediator = GetMediatorService(scope);
    //        await mediator.Send(command);
    //    }

    //    internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
    //    {
    //        using var scope = _serviceProvider.CreateScope();
    //        var mediator = GetMediatorService(scope);
    //        return await mediator.Send(command);
    //    }

    //    private static IMediator GetMediatorService(IServiceScope scope)
    //    {
    //        var mediator = scope.ServiceProvider.GetService<IMediator>();
    //        if (mediator == null)
    //            throw new ArgumentNullException(nameof(IMediator), "Cannot resolve IMediator from service provider");

    //        return mediator;
    //    }
    //}

}
