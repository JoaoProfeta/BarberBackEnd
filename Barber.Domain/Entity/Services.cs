using Barber.Domain.Enum;

namespace Barber.Domain.Entity
{
    public class Service : Entity
    {
        public Service(
            string name,
            EAvailabilityStatus status
            )
        {
            Name = name;
            ServiceStatus = status;
        }

        public string Name { get; private set; } = string.Empty;
        public EAvailabilityStatus ServiceStatus { get; private set; }
        public ICollection<Professional>? Professionals { get; set; }

        public void UpdateName(string name) => Name = name;
        public void UpdateStatus(EAvailabilityStatus status) => ServiceStatus = status;
                    
    }
}
