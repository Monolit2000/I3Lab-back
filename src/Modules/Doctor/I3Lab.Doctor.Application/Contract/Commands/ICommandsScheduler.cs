using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.Contract.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}
