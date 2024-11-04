
using I3Lab.Treatments.Application.Contract;

namespace I3Lab.Treatments.Application.Configuration.Commands
{
    public interface IHangFireCommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}
