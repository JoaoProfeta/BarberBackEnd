using Barber.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ProfessionalServiceRequest;

public sealed record DeleteProfessionalServiceCommandRequest(Guid Id) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
        .Requires()
            .IsFalse(Id == Guid.Empty, "Id", "Id não pode estar vazio");

        Notifications.AddRange(contract.Notifications);
    }
}

