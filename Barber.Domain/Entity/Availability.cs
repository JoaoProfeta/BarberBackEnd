using Barber.Domain.Enum;

namespace Barber.Domain.Entity;

public class Availability : Entity
{
    public Availability(
        Guid professionalId,
        EDayOfWeek dayOfWeek,
        TimeOnly startTime,
        TimeOnly endTime
    )
    {
        ProfessionalId = professionalId;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        IsActive = true;
    }

    public Guid ProfessionalId { get; private set; }
    public EDayOfWeek DayOfWeek { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public bool IsActive { get; private set; }
    
    public Professional Professional { get; private set; }

    public void UpdateWorkingHours(TimeOnly startTime, TimeOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public bool IsAvailableAtTime(TimeOnly time)
    {
        return IsActive && time >= StartTime && time <= EndTime;
    }
}