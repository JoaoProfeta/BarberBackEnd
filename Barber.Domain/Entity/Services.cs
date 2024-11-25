using Barber.Domain.Enum;

namespace Barber.Domain.Entity;
public class Service : Entity
{
    public Service(
        string name,
        EAvailabilityStatus status
        )
    {
        Name = name;
        ServiceStatus = status;
        Professionals = new List<ProfessionalServiceJoint>();
    }
    public string Name { get; private set; } = string.Empty;
    public EAvailabilityStatus ServiceStatus { get; private set; }
    public ICollection<ProfessionalServiceJoint> Professionals { get; private set; }
    public void UpdateName(string name) => Name = name;
    public void UpdateStatus(EAvailabilityStatus status) => ServiceStatus = status;

    public void AddProfessional(IEnumerable<Guid> professionalIds)
    {
        foreach (var professional in professionalIds)
        {
            if (!Professionals.Any(s => s.ProfessionalId == professional))
            {
                var create = new ProfessionalServiceJoint(this.Id, professional);
                if (!Professionals.Contains(create))
                    Professionals.Add(create);
            }
        }
    }

}
