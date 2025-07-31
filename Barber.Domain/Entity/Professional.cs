using Barber.Domain.Enum;

namespace Barber.Domain.Entity;

public class Professional : Entity
{
    public Professional(
        Guid userId,
        string description = "",
        decimal commissionPercentage = 0
    )
    {
        UserId = userId;
        Description = description;
        CommissionPercentage = commissionPercentage;
        Status = EAvailabilityStatus.Avaliable;
        Services = new List<ProfessionalServiceJoint>();
        Availabilities = new List<Availability>();
        TimeBlocks = new List<TimeBlock>();
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public Guid UserId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public decimal CommissionPercentage { get; private set; }
    public EAvailabilityStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    
    // Navigation Properties
    public User User { get; private set; }
    public ICollection<ProfessionalServiceJoint> Services { get; private set; }
    public ICollection<Availability> Availabilities { get; private set; }
    public ICollection<TimeBlock> TimeBlocks { get; private set; }

    public void UpdateDescription(string description) => Description = description;
    public void UpdateCommissionPercentage(decimal percentage) => CommissionPercentage = percentage;
    public void UpdateStatus(EAvailabilityStatus status) => Status = status;
    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public void AddService(Guid serviceId)
    {
        var create = new ProfessionalServiceJoint(serviceId, this.Id);
        if (!Services.Contains(create))
            Services.Add(create);
    }

    public void AddAvailability(EDayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime)
    {
        var availability = new Availability(this.Id, dayOfWeek, startTime, endTime);
        Availabilities.Add(availability);
    }

    public void AddTimeBlock(DateTime startDateTime, DateTime endDateTime, string reason)
    {
        var timeBlock = new TimeBlock(this.Id, startDateTime, endDateTime, reason);
        TimeBlocks.Add(timeBlock);
    }

    public bool IsAvailableAt(DateTime dateTime)
    {
        if (!IsActive || Status != EAvailabilityStatus.Avaliable)
            return false;

        // Verifica se há bloqueios de tempo para este horário
        if (TimeBlocks.Any(tb => tb.IsBlockingTime(dateTime)))
            return false;

        var dayOfWeek = (EDayOfWeek)(int)dateTime.DayOfWeek;
        var timeOnly = TimeOnly.FromDateTime(dateTime);

        return Availabilities.Any(a => 
            a.DayOfWeek == dayOfWeek && 
            a.IsAvailableAtTime(timeOnly));
    }
}
