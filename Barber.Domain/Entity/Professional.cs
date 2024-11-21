using Barber.Domain.Enum;

namespace Barber.Domain.Entity;
public class Professional : Entity
{
    public Professional(
        Guid userId,
        string professionalName,
        EAvailabilityStatus stats,
        ICollection<Service>? services
        )
    {
        ProfessionalId = userId;
        ProfessionalName = professionalName;
        Status = stats;
        Services = services;
    }
    public Guid ProfessionalId { get; private set; }
    public string ProfessionalName { get; private set; } = string.Empty;
    public EAvailabilityStatus Status { get; private set; }
    public ICollection<Service> Services { get; private set; } = new List<Service>();
    public ICollection<Scheduling> Schedulings { get; private set; } = new List<Scheduling>();
    public void UpdateProfessonalName(string name) => ProfessionalName = name;
    public void UpdateStatus(EAvailabilityStatus status) => Status = status;
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
        if (scheduling == null)
            throw new ArgumentNullException(nameof(scheduling));
        Schedulings.Remove(scheduling);
    }

}
