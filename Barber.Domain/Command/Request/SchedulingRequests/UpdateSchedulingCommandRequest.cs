using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Entity;
using Barber.Domain.Enum;

namespace Barber.Domain.Command.Request.SchedulingRequests
{
    public class UpdateSchedulingCommandRequest : ICommand
    {
        public UpdateSchedulingCommandRequest() { }
        public UpdateSchedulingCommandRequest(
        Guid id,
        DateTime schedulingTime,
        Guid professionalSelectedId,
        SchedulingStatus schedulingStatus,
        ICollection<Services> servicesSelected
        )
        {
            Id = id;
            SchedulingTime = schedulingTime;
            ProfessionalSelectedId = professionalSelectedId;
            SchedulingStatus = schedulingStatus;
            ServicesSelected = servicesSelected;
        }
        public Guid Id { get; private set; }
        public DateTime SchedulingTime { get; private set; }
        public Guid ProfessionalSelectedId { get; private set; }
        public SchedulingStatus SchedulingStatus { get; private set; }
        public ICollection<Services> ServicesSelected { get; private set; }
    }
}
