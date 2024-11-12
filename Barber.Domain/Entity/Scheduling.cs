using Barber.Domain.Enum;

namespace Barber.Domain.Entity
{
    public class Scheduling : Entity
    {

        public Scheduling(
            DateTime schedulingTime, 
            Guid professionalId,
            SchedulingStatus status,
            ICollection<Services> servicesSelected
            )
        {
            SchedulingTime = schedulingTime;
            ProfessionalSelectedId = professionalId;
            SchedulingStatus = status;
            ServicesSelected = servicesSelected;
        }
        
        public DateTime SchedulingTime { get; private set; }
        public Guid ProfessionalSelectedId { get; private set; }
        public SchedulingStatus SchedulingStatus { get; private set; }
        public ICollection<Services> ServicesSelected { get; private set; }



        public void UpdateScheduling(
            DateTime schedulingTime,
            Guid professionalId,
            SchedulingStatus status,
            ICollection<Services> servicesSelected
            ) 
        {

            SchedulingTime = schedulingTime;
            ProfessionalSelectedId = professionalId;
            SchedulingStatus = status;
            ServicesSelected = servicesSelected;

        }

        public void Update(
            DateTime? schedulingTime = null,
            Guid? professionalSelectedId = null,
            SchedulingStatus? status = null,
            ICollection<Services>? servicesSelected = null
            )
        {
            if (schedulingTime.HasValue)
                SchedulingTime = schedulingTime.Value;

            if (professionalSelectedId.HasValue)
                ProfessionalSelectedId = professionalSelectedId.Value;

            if (status.HasValue)
                SchedulingStatus = status.Value;

            if (servicesSelected != null)
                ServicesSelected = servicesSelected;
        }
    }
}
