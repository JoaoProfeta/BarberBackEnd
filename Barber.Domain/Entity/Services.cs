using Barber.Domain.Enum;

namespace Barber.Domain.Entity
{
    public class Services : Entity
    {
        public Services(
            string name,
            AvailabilityStatus status
            )
        {
            Name = name;
            ServiceStatus = status;
        }

        public string Name { get; private set; } = string.Empty;
        public AvailabilityStatus ServiceStatus { get; private set; }
        public ICollection<Professonals>? Professonals { get; set; }
        

        public void UpdateService(
            string? name = null,
            AvailabilityStatus? stats = null)
        {

            if (stats.HasValue)
                ServiceStatus = stats.Value;

            if (!string.IsNullOrEmpty(name)) 
                Name = name;


        }
    }
}
