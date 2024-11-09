using Hangfire;
using I3Lab.Users.Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Infrastructure.Processing.Hangfire
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
        public Task ExecuteCommand(IRequest command)
        {
            return sender.Send(command);
        }

        //[AutomaticRetry(Attempts = 3)]
        public Task ExecuteCommand<T>(IRequest<T> command)
        {
            return sender.Send(command);
        }
    }
}
