using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;
namespace Barber.Domain.Command.Request.ProfessonalRequests;
public sealed record CreateProfessionalCommandRequest(
        Guid ProfessionalId,
        string ProfessionalName,
        EAvailabilityStatus Status
        ) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsFalse(ProfessionalId == Guid.Empty, "Profissional Id", "Id do profissional Nao pode estar vazio")
            .IsNotNullOrEmpty(ProfessionalName, "Nome", "O nome nao pode ser vazio")
            .IsGreaterThan(ProfessionalName.Length, 3, "Nome", "Nome deve conter no minimo 3 caracteres");

        Notifications.AddRange(contract.Notifications);
    }
}