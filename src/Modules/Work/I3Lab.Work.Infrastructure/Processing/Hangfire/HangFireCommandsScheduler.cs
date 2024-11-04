using Hangfire;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Contract;
using MediatR;

namespace I3Lab.Treatments.Infrastructure.Processing.Hangfire
{
    public class HangFireCommandsScheduler( 
        ISender sender,
        IBackgroundJobClient _backgroundJobClient) : IHangFireCommandsScheduler
    {
        public Task EnqueueAsync(ICommand command)
        {
            _backgroundJobClient.Enqueue(() => ExecuteCommand(command));
            return Task.CompletedTask;
        }

        public Task EnqueueAsync<T>(ICommand<T> command)
        {
            _backgroundJobClient.Enqueue(() => ExecuteCommand(command));
            return Task.CompletedTask;
        }

        //[AutomaticRetry(Attempts = 3)]
        public Task ExecuteCommand(ICommand command)
        {
             return sender.Send(command);
        }

        //[AutomaticRetry(Attempts = 3)]
        public Task ExecuteCommand<T>(ICommand<T> command)
        {
            return sender.Send(command);
        }
    }
}