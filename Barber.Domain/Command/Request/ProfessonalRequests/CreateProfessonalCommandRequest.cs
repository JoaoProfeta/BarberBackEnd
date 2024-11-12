using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;

namespace Barber.Domain.Command.Request.ProfessonalRequests;

public class CreateProfessonalCommandRequest : ICommand
{
    public CreateProfessonalCommandRequest(
        Guid professonalId,
        string professonalName,
        AvailabilityStatus stats,
        ICollection<Services>? services
        )
    {
        ProfessonalId = professonalId;
        ProfessonalName = professonalName;
        Stats = stats;
        Services = services;
    }

    public Guid ProfessonalId { get; private set; }
    public string ProfessonalName { get; private set; } = string.Empty;
    public AvailabilityStatus Stats { get; private set; }
    public ICollection<Services>? Services { get; private set; }
}