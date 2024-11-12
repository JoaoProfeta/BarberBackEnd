using Barber.Domain.Enum;
using System.Xml.Linq;

namespace Barber.Domain.Entity
{
    public class Professonals : Entity
    {

        public Professonals(
            Guid userId,
            string professonalName,
            AvailabilityStatus stats,
            ICollection<Services>? services
            )
        {
            ProfessonalId = userId;
            ProfessonalName = professonalName;
            Stats = stats;
            Services = services;

        }

        public Guid ProfessonalId { get; private set; }
        public string ProfessonalName { get; private set; } = string.Empty;
        public AvailabilityStatus Stats { get; private set; }
        public ICollection<Services>? Services { get; set; }
        public ICollection<Scheduling>? Schedulings { get; set; }

        public void UpdateProfessonal(
            Guid? professonalId = null,
            string? professonalName = null,
            AvailabilityStatus? stats = null,
            ICollection<Services>? services = null,
            ICollection<Scheduling>? schedulings = null
            )
        {
            if (professonalId.HasValue)
                ProfessonalId = professonalId.Value;

            if (!string.IsNullOrEmpty(professonalName))
                ProfessonalName = professonalName;

            if (stats.HasValue)
                Stats = stats.Value;

            if (services != null)
                Services = services;

            if (schedulings != null)
                Schedulings = schedulings;
        }

    }
}
