using Barber.Domain.Enum;

namespace Barber.Domain.Entity;
public class Service : Entity
{
    public Service(
        string name,
        string description,
        decimal price,
        int durationInMinutes,
        EAvailabilityStatus status = EAvailabilityStatus.Avaliable
    )
    {
        Name = name;
        Description = description;
        Price = price;
        DurationInMinutes = durationInMinutes;
        ServiceStatus = status;
        Professionals = new List<ProfessionalServiceJoint>();
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int DurationInMinutes { get; private set; }
    public EAvailabilityStatus ServiceStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    public ICollection<ProfessionalServiceJoint> Professionals { get; private set; }

    public void UpdateName(string name) => Name = name;
    public void UpdateDescription(string description) => Description = description;
    public void UpdatePrice(decimal price) => Price = price;
    public void UpdateDuration(int durationInMinutes) => DurationInMinutes = durationInMinutes;
    public void UpdateStatus(EAvailabilityStatus status) => ServiceStatus = status;
    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

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
