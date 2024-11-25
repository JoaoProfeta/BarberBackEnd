using Barber.Domain.Command.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ProfessionalServiceRequest;

public sealed record CreateProfessionalServiceCommandRequest(
        Guid ServiceId,
        Guid ProfessionalId) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsFalse(ServiceId == Guid.Empty, "Service Id", "Id do servico não pode estar vazio")
            .IsFalse(ProfessionalId == Guid.Empty, "Profissional Id", "Id do profissional Nao pode estar vazio");

        Notifications.AddRange(contract.Notifications);
    }
}

