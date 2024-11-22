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
            .IsFalse(Id == Guid.Empty, "Id", "Id nao pode estar vazio")
            .IsNotNullOrEmpty(Name, "Name", "O nome nao pode ser vazio")
            .IsGreaterThan(Name.Length, 3, "Nome", "Nome deve conter no minimo 3 caracteres");

        Notifications.AddRange(contract.Notifications);
    }
}
