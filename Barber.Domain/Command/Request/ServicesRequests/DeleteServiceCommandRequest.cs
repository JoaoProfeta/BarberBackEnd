using Barber.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ServicesRequests;
public sealed record DeleteServiceCommandRequest(Guid Id) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Id, "Id", "Selecione o Profissional");

        Notifications.AddRange(contract.Notifications);
    }
}
