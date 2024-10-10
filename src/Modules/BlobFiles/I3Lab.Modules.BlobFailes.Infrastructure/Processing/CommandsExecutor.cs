using MediatR;
using I3Lab.BuildingBlocks.Infrastructure;
using I3Lab.Modules.BlobFailes.Application.Contract;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Processing
{
    public static class CommandsExecutor
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
