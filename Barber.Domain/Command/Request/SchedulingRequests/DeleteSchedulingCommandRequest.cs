using Barber.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.SchedulingRequests;
public sealed record DeleteSchedulingCommandRequest(Guid Id) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Id, "Id", "Selecione o Agendamento");

        Notifications.AddRange(contract.Notifications);
    }
}
