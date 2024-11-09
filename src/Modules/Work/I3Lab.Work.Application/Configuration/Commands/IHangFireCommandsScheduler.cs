
using I3Lab.Treatments.Application.Contract;
using MediatR;

namespace I3Lab.Treatments.Application.Configuration.Commands
{
    public interface IHangFireCommandsScheduler
    {
        Task EnqueueAsync(IRequest command);

        Task EnqueueAsync<T>(IRequest<T> command);
    }
}
