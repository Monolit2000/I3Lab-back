using MediatR;
using I3Lab.Works.Application.Contract;

namespace I3Lab.Works.Application.Configuration.Commands
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
