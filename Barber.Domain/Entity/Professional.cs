using Barber.Domain.Enum;
using System.Xml.Linq;

namespace Barber.Domain.Entity
{
    public class Professional : Entity
    {

        public Professional(
            Guid userId,
            string professonalName,
            EAvailabilityStatus stats,
            ICollection<Service>? services
            )
        {
            ProfessonalId = userId;
            ProfessonalName = professonalName;
            Status = stats;
            Services = services;

        }

        public Guid ProfessonalId { get; private set; }
        public string ProfessonalName { get; private set; } = string.Empty;
        public EAvailabilityStatus Status { get; private set; }
        public ICollection<Service> Services { get; private set; } = new List<Service>();
        public ICollection<Scheduling> Schedulings { get; private set; } = new List<Scheduling>();

        public void UpdateProfessonalName(  string name ) => ProfessonalName = name;
        public void UpdateStatus( EAvailabilityStatus status ) => Status = status;

        public void AddService(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            Services.Add(service);
        }
        public void RemoveService(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            Services.Remove(service);
        }


        public void AddScheduling(Scheduling scheduling)
        {
            if (scheduling == null)
                throw new ArgumentNullException(nameof(scheduling));
            Schedulings.Add(scheduling);
        }
        public void RemoveService(Scheduling scheduling)
        {
            if(scheduling == null)
                throw new ArgumentNullException(nameof(scheduling));
            Schedulings.Remove(scheduling);
        }

    }
}
