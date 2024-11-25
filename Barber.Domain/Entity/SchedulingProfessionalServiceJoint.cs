namespace Barber.Domain.Entity;

public class SchedulingProfessionalServiceJoint : Entity
{
    public SchedulingProfessionalServiceJoint(Guid schedulingId, Guid professionalServiceJointsId)
    {
        SchedulingId = schedulingId;
        ProfessionalServiceJointId = professionalServiceJointsId;
    }
    public Guid SchedulingId { get; private set; }
    public Guid ProfessionalServiceJointId { get; private set; }

    public Scheduling Scheduling { get; private set; }
    public ProfessionalServiceJoint ProfessionalServiceJoint { get; private set; }
}
