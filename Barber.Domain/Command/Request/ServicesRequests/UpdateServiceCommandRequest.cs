using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Enum;

namespace Barber.Domain.Command.Request.ServicesRequests
{
    public class UpdateServiceCommandRequest : ICommand
    {
        public UpdateServiceCommandRequest() { }
        public UpdateServiceCommandRequest(
            Guid id,
            string name,
            AvailabilityStatus status
            )
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public AvailabilityStatus Status { get; private set; }
    }
}
