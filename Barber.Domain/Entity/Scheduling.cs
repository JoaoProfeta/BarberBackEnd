using Barber.Domain.Enum;

namespace Barber.Domain.Entity;
public class Scheduling : Entity
{
    public Scheduling(
        DateTime schedulingTime,
        Guid professionalId,
        ESchedulingStatus status,
        ICollection<Service> servicesSelected
        )
    {
        SchedulingTime = schedulingTime;
        ProfessionalSelectedId = professionalId;
        SchedulingStatus = status;
        Services = servicesSelected;
    }
    public DateTime SchedulingTime { get; private set; }
    public Guid ProfessionalSelectedId { get; private set; }
    public ESchedulingStatus SchedulingStatus { get; private set; }
    public ICollection<Service> Services { get; private set; } = new List<Service>();
    public void UpdateDate(DateTime date) => SchedulingTime = date;
    public void UpdateProfessonalSelected(Guid professionalId) => ProfessionalSelectedId = professionalId;
    public void UpdateSchedulingStatus(ESchedulingStatus status) => SchedulingStatus = status;
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
}
