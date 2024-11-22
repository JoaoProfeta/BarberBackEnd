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
            .IsFalse(Id == Guid.Empty, "Id", "Id nao pode estar vazio")
            .IsFalse(SchedulingTime == DateTime.MinValue, "data", "Adicione um horario correto para agendar")
            .IsFalse(ProfessionalSelectedId == Guid.Empty, "Profissional", "Adicione um prifissional")
            .IsGreaterOrEqualsThan(ServicesSelected?.Count ?? 0, 1, "Servico", "Adicione ao menos 1 servico");

        Notifications.AddRange(contract.Notifications);
    }
}
