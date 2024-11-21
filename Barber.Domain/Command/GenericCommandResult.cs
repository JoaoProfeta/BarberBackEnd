using Barber.Domain.Command.Contracts;

namespace Barber.Domain.Command;
public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult() { }
    public GenericCommandResult(bool sucess, string message)
    {
        Success = sucess;
        Message = message;
    }
    public GenericCommandResult(bool sucess, string message, object? data)
    {
        Success = sucess;
        Message = message;
        Data = data;
    }
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public object? Data { get; private set; }
}
