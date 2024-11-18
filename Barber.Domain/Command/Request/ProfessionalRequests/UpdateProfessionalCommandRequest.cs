using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public sealed record UpdateProfessionalCommandRequest(
            Guid Id,
            Guid ProfessionalId,
            string ProfessionalName,
            EAvailabilityStatus Status,
            ICollection<Service>? Services) : ICommand
    {
        public List<Notification> Notifications { get; private set; } = new();
        public bool IsValid => Notifications.Count == 0;
        public void Validate()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Id, "Id", "O nome não pode ser vazio")
                .IsNotNull(ProfessionalId, "Professional ID", "Id do profissional Não pode estar vazio")
                .IsGreaterOrEqualsThan(ProfessionalName, 3, "Nome deve conter no minimo 3 caracteres");

            Notifications.AddRange(contract.Notifications);

        }
    }
   
}
