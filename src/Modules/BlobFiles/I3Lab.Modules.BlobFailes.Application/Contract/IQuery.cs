using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.Contract
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
