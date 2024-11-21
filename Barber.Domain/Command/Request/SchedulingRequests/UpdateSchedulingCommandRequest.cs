using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.SchedulingRequests;
public sealed record UpdateSchedulingCommandRequest(
    Guid Id,
    DateTime SchedulingTime,
    Guid ProfessionalSelectedId,
    ESchedulingStatus Status,
    ICollection<Service> ServicesSelected) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(SchedulingTime, "data", "Selecione o horario de agendamento")
            .IsNotNull(ProfessionalSelectedId, "Profissional", "Selecione o prifissional")
            .IsGreaterOrEqualsThan(ServicesSelected, 1, "Selecione ao menos 1 serviço");

        Notifications.AddRange(contract.Notifications);
    }
}
