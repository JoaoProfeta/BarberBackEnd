using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;

namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public sealed record UpdateProfessonalCommandRequest(
            Guid Id,
            Guid ProfessonalId,
            string ProfessonalName,
            EAvailabilityStatus Status,
            ICollection<Service>? Services) : ICommand
    {
        public List<Notification> Notifications { get; private set; } = new();
        public bool IsValid => Notifications.Count == 0;
        public void Validate()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(ProfessonalName, "Nome", "O nome não pode ser vazio")
                .IsGreaterOrEqualsThan(ProfessonalName, 3, "Nome", "O nome deve conter no minimo 3 letras")
                .IsGreaterOrEqualsThan(Services, 1, "Serviços", "Adicione pelomenos 1 serviço");
            Notifications.AddRange(contract.Notifications);

        }
    }
   
}
