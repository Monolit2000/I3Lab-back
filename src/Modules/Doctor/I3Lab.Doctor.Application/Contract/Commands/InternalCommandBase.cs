using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.Contract.Commands
{
    public abstract class InternalCommandBase : CommandBase, ICommand
    {

    }

    public abstract class InternalCommandBase<TResult> : CommandBase<TResult>, ICommand<TResult>
    {
    
    }
}
