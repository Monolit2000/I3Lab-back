using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Contract
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface ICommand : IRequest
    {
        Guid Id { get; }
    }
}
