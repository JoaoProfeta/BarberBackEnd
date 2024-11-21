using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Handler.SchedulingHandle;

public class DeleteSchedulingHandle : IHandler<DeleteSchedulingCommandRequest>
{
    private readonly ISchedulingRepository _schedulingRepository;
    public DeleteSchedulingHandle(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }
    public async Task<ICommandResult> Handle(DeleteSchedulingCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Identificador unico errado");

            var scheduling = await _schedulingRepository.GetByIdAsync(command.Id);

            if (scheduling == null)
                return new GenericCommandResult(false, "Agendamento não encontrado");

            await _schedulingRepository.DeleteAsync(scheduling);

            return new GenericCommandResult(
                sucess: true,
                message: "Scheduling Deleted"
                );
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(false, "erro ao deletar Agendamento");
        }

    }
}

