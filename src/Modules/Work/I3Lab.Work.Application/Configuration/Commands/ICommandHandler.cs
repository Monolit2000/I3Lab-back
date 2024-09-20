using MediatR;
using I3Lab.Treatments.Application.Contract;

namespace I3Lab.Treatments.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> 
        : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}
