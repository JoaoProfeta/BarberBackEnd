using Barber.Domain.Command.Contracts;

namespace Barber.Domain.Command.Request.ServicesRequests
{
    public class DeleteServiceCommandRequest : ICommand
    {
        public DeleteServiceCommandRequest() { }
        public DeleteServiceCommandRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
