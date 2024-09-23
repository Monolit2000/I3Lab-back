using I3Lab.Modules.BlobFailes.Application.Contract;
using MediatR;
using I3Lab.Modules.BlobFailes.Infrastructure.Processing;

namespace I3Lab.Modules.BlobFailes.Infrastructure
{
    public class BlobFilesModule : IBlobFilesModule
    {
        private readonly IMediator _mediator;

        public BlobFilesModule(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}
