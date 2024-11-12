using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;


namespace Barber.Domain.Command.Request.SchedulingRequests;

public class CreateSchedulingCommandRequest : ICommand
{
    public CreateSchedulingCommandRequest() { }

    public CreateSchedulingCommandRequest(
        DateTime schedulingTime,
        Guid professionalSelectedId,
        SchedulingStatus schedulingStatus,
        ICollection<Services> servicesSelected
        )
    {
        SchedulingTime = schedulingTime;
        ProfessionalSelectedId = professionalSelectedId;
        SchedulingStatus = schedulingStatus;
        ServicesSelected = servicesSelected;
    }

    public DateTime SchedulingTime { get; private set; }
    public Guid ProfessionalSelectedId { get; private set; }
    public SchedulingStatus SchedulingStatus { get; private set; }
    public ICollection<Services> ServicesSelected { get; private set; }


}