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
            .IsNotNull(SchedulingTime, "Agendar", "adicione um horario para agendar")
            .IsNotNull(ProfessionalSelectedId, "Profissional", "Adicione um profissional")
            .IsGreaterOrEqualsThan(ServicesSelected, 1, "Adicione pelomenos 1 serviço");
        Notifications.AddRange(contract.Notifications);
    }


}