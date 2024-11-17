using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ServicesRequests
{

    public sealed record CreateServiceCommandRequest(
            string Name,
            EAvailabilityStatus Status) : ICommand
    {
        public List<Notification> Notifications { get; private set; } = new();
        public bool IsValid => Notifications.Count == 0;

        public void Validate()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Nome", "Adicione um Nome")
                .IsGreaterOrEqualsThan(Name, 3, "Nome do serviço pequeno");
            Notifications.AddRange(contract.Notifications);
        }
    }
}