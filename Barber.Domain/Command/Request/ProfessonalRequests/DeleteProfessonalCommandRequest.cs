using Barber.Domain.Command.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Command.Request.ProfessonalRequests
{
    public class DeleteProfessonalCommandRequest : ICommand
    {
        public DeleteProfessonalCommandRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
