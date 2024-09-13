using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Contract
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }

        protected CommandBase()
        {
            Id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        protected CommandBase()
        {
            Id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
