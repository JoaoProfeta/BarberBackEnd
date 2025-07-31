namespace Barber.Domain.Entity;

public class TimeBlock : Entity
{
    public TimeBlock(
        Guid professionalId,
        DateTime startDateTime,
        DateTime endDateTime,
        string reason
    )
    {
        ProfessionalId = professionalId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Reason = reason;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid ProfessionalId { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public string Reason { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public Professional Professional { get; private set; }

    public void UpdateTimeBlock(DateTime startDateTime, DateTime endDateTime)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

    public void UpdateReason(string reason) => Reason = reason;
    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public bool IsBlockingTime(DateTime dateTime)
    {
        return IsActive && dateTime >= StartDateTime && dateTime <= EndDateTime;
    }
}