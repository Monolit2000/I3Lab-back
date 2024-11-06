using MediatR;
using Hangfire;
using I3Lab.Clinics.Application.Contruct;

namespace I3Lab.Clinics.Infrastructure.Processing.Hangfire
{
    public class HangFireCommandsScheduler(
       ISender sender,
       IBackgroundJobClient _backgroundJobClient) : IHangFireCommandsScheduler
    {
        public Task EnqueueAsync(IRequest command)
        {
            _backgroundJobClient.Enqueue(() => ExecuteCommand(command));
            return Task.CompletedTask;
        }

        public Task EnqueueAsync<T>(IRequest<T> command)
        {
            _backgroundJobClient.Enqueue(() => ExecuteCommand(command));
            return Task.CompletedTask;
        }

        //[AutomaticRetry(Attempts = 3)]
        private Task ExecuteCommand(IRequest command)
        {
            return sender.Send(command);
        }

        //[AutomaticRetry(Attempts = 3)]
        private Task ExecuteCommand<T>(IRequest<T> command)
        {
            return sender.Send(command);
        }
    }
}
