using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
using Flunt.Notifications;
using Flunt.Validations;
namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public sealed record CreateProfessonalCommandRequest(
            Guid ProfessonalId,
            string ProfessonalName,
            EAvailabilityStatus Status,
            ICollection<Service> Services) : ICommand
    {
        public List<Notification> Notifications { get; private set; } = new();
        public bool IsValid => Notifications.Count  == 0;

        public void Validate()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsGreaterThan( ProfessonalName.Length, 3, "Nome", "O nome deve conter no minimo 3 letras" )
                .IsNotNullOrEmpty( ProfessonalName, "Nome", "O nome não pode ser vazio" )
                .IsGreaterThan( Services.Count, 1, "Serviços", "Adicione pelomenos 1 serviço" )
                .IsNotNull( Services, "Serviços", "Adicione serviços" );

            Notifications.AddRange(contract.Notifications);

        }
    }
}