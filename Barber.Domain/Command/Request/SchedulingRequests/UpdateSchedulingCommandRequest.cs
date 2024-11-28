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
    ESchedulingStatus Status,
    ICollection<ProfessionalServiceJoint> ProfessionalService) : ICommand
{
    public List<Notification> Notifications { get; private set; } = new();
    public bool IsValid => Notifications.Count == 0;
    public void Validate()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsFalse(Id == Guid.Empty, "Id", "Id nao pode estar vazio")
            .IsFalse(SchedulingTime == DateTime.MinValue, "Data", "Adicione um horario correto para agendar")
            .IsFalse(ProfessionalService.FirstOrDefault().ServiceId == Guid.Empty, "Servico", "Adicione um servico e um profissional")
            .IsFalse(ProfessionalService.FirstOrDefault().ProfessionalId == Guid.Empty, "Profissional", "Adicione um servico e um profissional")
            .IsGreaterOrEqualsThan(ProfessionalService?.Count ?? 0, 1, "Professional e serviços", "Adicione um servico e um profissional");

        Notifications.AddRange(contract.Notifications);
    }
}
