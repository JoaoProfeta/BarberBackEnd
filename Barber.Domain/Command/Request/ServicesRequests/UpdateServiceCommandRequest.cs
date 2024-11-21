using Barber.Domain.Command.Contracts;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ServicesRequests;
public sealed record UpdateServiceCommandRequest(
        Guid Id,
        string Name,
        EAvailabilityStatus Status) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Id, "Id", "Selecione um serviço")
            .IsNotNullOrEmpty(Name, "Name", "Adicione um nome")
            .IsGreaterOrEqualsThan(Name, 3, "Nome deve ter no minimo 3 letras");

        Notifications.AddRange(contract.Notifications);
    }
}
