namespace Barber.Domain.Entity;

public class ProfessionalServiceJoint : Entity
{
    public ProfessionalServiceJoint(Guid serviceId, Guid professionalId)
    {
        ServiceId = serviceId;
        ProfessionalId = professionalId;
    }
    public Guid ServiceId { get; private set; }
    public Guid ProfessionalId { get; private set; }

    public Professional Professional { get; private set; }
    public Service Service { get; private set; }
}

