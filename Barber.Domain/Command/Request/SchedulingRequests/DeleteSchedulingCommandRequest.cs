using Barber.Domain.Command.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Command.Request.SchedulingRequests
{
    public class DeleteSchedulingCommandRequest : ICommand
    {
        public DeleteSchedulingCommandRequest(Guid id)
        {
            Id = id;
        }

        DeleteSchedulingCommandRequest() { }

        public Guid Id { get; private set; }
    }
}
