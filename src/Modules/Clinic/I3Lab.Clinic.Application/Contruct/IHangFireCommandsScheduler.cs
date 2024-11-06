using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Application.Contruct
{
    public interface IHangFireCommandsScheduler
    {
        Task EnqueueAsync(IRequest command);

        Task EnqueueAsync<T>(IRequest<T> command);
    }
}
