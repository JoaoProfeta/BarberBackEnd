using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.SchedulingProfessionalServiceRequest;

public sealed record UpdateSchedulingProfessionalServiceCommandRequest(
        Guid SchedulingId,
        Guid ProfessionalServiceId)
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
        .Requires()
            .IsFalse(SchedulingId == Guid.Empty, "Service Id", "Id do servico não pode estar vazio")
            .IsFalse(ProfessionalServiceId == Guid.Empty, "Profissional Id", "Id do profissional Nao pode estar vazio");

        Notifications.AddRange(contract.Notifications);
    }
}

