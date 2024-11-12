using Barber.Domain.Command.Contracts;
using Barber.Domain.Enum;

namespace Barber.Domain.Command.Request.ServicesRequests
{

    public class CreateServiceCommandRequest : ICommand
    {
        public CreateServiceCommandRequest() { }
        public CreateServiceCommandRequest(
            string name,
            AvailabilityStatus status
            )
        {
            Name = name;
            Status = status;
        }

        public string Name { get; private set; }
        public AvailabilityStatus Status { get; private set; }
    }
}