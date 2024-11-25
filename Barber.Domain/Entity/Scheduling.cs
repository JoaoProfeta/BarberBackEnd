using Barber.Domain.Enum;

namespace Barber.Domain.Entity;
public class Scheduling : Entity
{
    public Scheduling(
        DateTime schedulingTime,
        ESchedulingStatus status
        )
    {
        SchedulingTime = schedulingTime;
        SchedulingStatus = status;
        SchedulingProfessionalsServices = new List<SchedulingProfessionalServiceJoint>();
    }
    public DateTime SchedulingTime { get; private set; }
    public ESchedulingStatus SchedulingStatus { get; private set; }
    public ICollection<SchedulingProfessionalServiceJoint> SchedulingProfessionalsServices { get; private set; }
    public void UpdateDate(DateTime date) => SchedulingTime = date;
    public void UpdateSchedulingStatus(ESchedulingStatus status) => SchedulingStatus = status;

    public void AddProfessionalService(IEnumerable<ProfessionalServiceJoint> professionalServiceJoint)
    {
        foreach (var item in professionalServiceJoint)
        {
            if (!SchedulingProfessionalsServices.Any(s => s.ProfessionalServiceJointId == item.Id))
            {
                var create = new SchedulingProfessionalServiceJoint(this.Id, item.Id);
                if (!SchedulingProfessionalsServices.Contains(create))
                    SchedulingProfessionalsServices.Add(create);
            }
        }
    }
    public void RemoveProfessionalService(ProfessionalServiceJoint professionalServiceJoint)
    {
        SchedulingProfessionalsServices.Remove(new SchedulingProfessionalServiceJoint(this.Id, professionalServiceJoint.Id));
    }
}
