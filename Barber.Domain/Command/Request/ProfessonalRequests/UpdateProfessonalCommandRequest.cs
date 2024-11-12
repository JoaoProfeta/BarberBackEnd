using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;

namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public class UpdateProfessonalCommandRequest : ICommand
    {
        public UpdateProfessonalCommandRequest(
            Guid id, 
            Guid professonalId, 
            string professonalName, 
            AvailabilityStatus stats, 
            ICollection<Services>? services)
        {
            Id = id;
            ProfessonalId = professonalId;
            ProfessonalName = professonalName;
            Stats = stats;
            Services = services;
        }

        public Guid Id { get; private set; }
        public Guid ProfessonalId { get; private set; }
        public string ProfessonalName { get; private set; } = String.Empty;
        public AvailabilityStatus Stats { get; private set; }
        public ICollection<Services>? Services { get; private set; }
    }
}
