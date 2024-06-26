using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure
{
    internal interface IUnitOfWork
    {
        Task<int> CommitAsync(
          CancellationToken cancellationToken = default,
          Guid? internalCommandId = null);
    }
}
