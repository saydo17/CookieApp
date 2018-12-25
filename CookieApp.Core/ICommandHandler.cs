using CSharpFunctionalExtensions;

namespace CookieApp.Core
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}