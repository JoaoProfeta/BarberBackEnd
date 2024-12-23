﻿using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.SchedulingHandle;

public class UpdateSchedulingHandle : IHandler<UpdateSchedulingCommandRequest>
{
    private readonly ISchedulingRepository _schedulingRepository;
    public UpdateSchedulingHandle(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }
    public async Task<ICommandResult> Handle(UpdateSchedulingCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao identificar agendamento");

            var scheduling = await _schedulingRepository.GetByIdAsync(command.Id);

            if (scheduling == null)
                return new GenericCommandResult(false, "Scheduling not found");

            if (command.SchedulingTime != null && !command.SchedulingTime.Equals(scheduling.SchedulingTime))
                scheduling.UpdateDate(command.SchedulingTime);

            if (command.Status != scheduling.SchedulingStatus)
                scheduling.UpdateSchedulingStatus(command.Status);

            if (command.ProfessionalService != null)
            {
                foreach (var item in command.ProfessionalService)
                {
                    scheduling.AddProfessionalService(scheduling.Id, item.Id);

                }
            }

            await _schedulingRepository.UpdateAsync(scheduling);

            return new GenericCommandResult(
                sucess: true,
                message: "Atualizado com sucesso",
                data: new
                {
                    scheduling.Id,
                    scheduling.SchedulingTime,
                    scheduling.SchedulingStatus,
                });
        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Erro ao Atualizar Agendamento");
        }

    }
}

