using Barber.Domain.Command.Contracts;

namespace Barber.Domain.Handler.Contracts;

public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> Handle(T command);
}
