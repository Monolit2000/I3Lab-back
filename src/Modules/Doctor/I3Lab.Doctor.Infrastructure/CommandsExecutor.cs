using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Doctors.Application.Contract.Commands;
using MediatR;

namespace I3Lab.Doctors.Infrastructure
{
    internal static class CommandsExecutor
    {
        private static IServiceProvider _serviceProvider;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

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
}
