using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;
namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public sealed record CreateProfessionalCommandRequest(
            Guid ProfessionalId,
            string ProfessionalName,
            EAvailabilityStatus Status,
            ICollection<Service> Services) : ICommand
    {
        public List<Notification> Notifications { get; private set; } = new();
        public bool IsValid => Notifications.Count  == 0;
        
        public void Validate()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsGreaterThan(ProfessionalName.Length, 3, "Nome", "O nome deve conter no minimo 3 letras")
                .IsNotNullOrEmpty(ProfessionalName, "Nome", "O nome não pode ser vazio");

            Notifications.AddRange(contract.Notifications);

        }
    }
}