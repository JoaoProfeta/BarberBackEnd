using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.SchedulingRequests;

public sealed record CreateSchedulingCommandRequest(
        DateTime SchedulingTime,
        Guid ProfessionalSelectedId,
        ESchedulingStatus SchedulingStatus,
        ICollection<Service> ServicesSelected) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsFalse(SchedulingTime == DateTime.MinValue, "Agendar", "adicione um horario correto para agendar")
            .IsFalse(ProfessionalSelectedId == Guid.Empty, "Profissional", "Adicione um profissional")
            .IsGreaterOrEqualsThan(ServicesSelected?.Count ?? 0, 1, "servicos", "Adicione ao menos 1 servico");
        Notifications.AddRange(contract.Notifications);
    }


}