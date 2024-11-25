using Barber.Domain.Enum;

namespace Barber.Domain.Entity;

public class Professional : Entity
{
    public Professional(
        Guid userId,
        string professionalName,
        EAvailabilityStatus stats
        )
    {
        ProfessionalId = userId;
        ProfessionalName = professionalName;
        Status = stats;
        Services = new List<ProfessionalServiceJoint>();
    }
    public Guid ProfessionalId { get; private set; }
    public string ProfessionalName { get; private set; } = string.Empty;
    public EAvailabilityStatus Status { get; private set; }
    public ICollection<ProfessionalServiceJoint> Services { get; private set; }
    public void UpdateProfessonalName(string name) => ProfessionalName = name;
    public void UpdateStatus(EAvailabilityStatus status) => Status = status;

    public void AddService(IEnumerable<Guid> serviceIds)
    {
        foreach (var service in serviceIds)
        {
            if (!Services.Any(s => s.ServiceId == service))
            {
                var create = new ProfessionalServiceJoint(service, this.Id);
                if(!Services.Contains(create))
                    Services.Add(create);
            }
        }
    }
    
}
