using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ProfessonalRequests;
public sealed record UpdateProfessionalCommandRequest(
        Guid Id,
        Guid ProfessionalId,
        string ProfessionalName,
        EAvailabilityStatus Status,
        ICollection<ProfessionalServiceJoint> Services) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsFalse(Id == Guid.Empty, "Id", "Id nao pode estar vazio")
            .IsFalse(ProfessionalId == Guid.Empty, "Professional ID", "Id do profissional Nao pode estar vazio")
            .IsNotNullOrEmpty(ProfessionalName, "Nome", "O nome nao pode ser vazio")
            .IsGreaterThan(ProfessionalName.Length, 3,"Nome","Nome deve conter no minimo 3 caracteres");

        Notifications.AddRange(contract.Notifications);
    }
}

