using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public sealed record DeleteProfessionalCommandRequest(Guid Id) : ICommand
    {
        public List<Notification> Notifications { get; private set; } = new();
        public bool IsValid => Notifications.Count == 0;
        public void Validate()
        {

            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Id, "Id", "Selecione o Profissional");
            Notifications.AddRange(contract.Notifications);
        }
    }
}
