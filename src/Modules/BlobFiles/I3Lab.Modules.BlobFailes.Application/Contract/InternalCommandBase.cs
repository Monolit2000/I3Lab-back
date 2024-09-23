using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.Contract
{
    public abstract class InternalCommandBase : CommandBase;


    public abstract class InternalCommandBase<TResult> : CommandBase<TResult>;
  
}
