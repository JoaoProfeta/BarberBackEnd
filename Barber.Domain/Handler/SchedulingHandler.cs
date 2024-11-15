using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler;

public class SchedulingHandler :
    IHandler<CreateSchedulingCommandRequest>,
    IHandler<UpdateSchedulingCommandRequest>,
    IHandler<DeleteSchedulingCommandRequest>
    
{
    private readonly ISchedulingRepository _schedulingRepository;

    public SchedulingHandler(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }


    public async Task<ICommandResult> Handle(CreateSchedulingCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "falha ao criar Agendamento");

            var scheduling = new Scheduling(
               command.SchedulingTime,
               command.ProfessionalSelectedId,
               command.SchedulingStatus,
               command.ServicesSelected
               );

            await _schedulingRepository.CreateAsync(scheduling);

            return new GenericCommandResult(
                sucess: true,
                message: "Schuling Created",
                data: new
                {
                    scheduling.Id,
                    scheduling.SchedulingTime,
                    scheduling.ProfessionalSelectedId,
                    scheduling.SchedulingStatus,
                    scheduling.Services

                }
             );
        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Falha ao agendar");
        }

    }

    public async Task<ICommandResult> Handle(UpdateSchedulingCommandRequest command)
    {
        try
        {
            command.Validate();
            if(!command.IsValid)
                return new GenericCommandResult(false, "Erro ao identificar agendamento");

            var scheduling = await _schedulingRepository.GetByIdAsync(command.Id);

            if (scheduling == null)
                return new GenericCommandResult(false, "Scheduling not found");

            if( command.SchedulingTime != null && !command.SchedulingTime.Equals(scheduling.SchedulingTime) )
                scheduling.UpdateDate(command.SchedulingTime);

            if( command.Status != scheduling.SchedulingStatus)
                scheduling.UpdateSchedulingStatus(command.Status);

            if( command.ProfessionalSelectedId != scheduling.ProfessionalSelectedId)
                scheduling.UpdateProfessonalSelected(command.ProfessionalSelectedId);

            await _schedulingRepository.UpdateAsync(scheduling);

            return new GenericCommandResult(
                sucess: true,
                message: "Atualizado com sucesso",
                data: new
                {
                    scheduling.Id,
                    scheduling.SchedulingTime,
                    scheduling.ProfessionalSelectedId,
                    scheduling.SchedulingStatus,
                    scheduling.Services
                });

        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Erro ao Atualizar Agendamento");
        }

    }

    public async Task<ICommandResult> Handle(DeleteSchedulingCommandRequest command)
    {
        try
        {
            command.Validate();
            if(!command.IsValid)
                return new GenericCommandResult(false, "Identificador unico errado");

            var scheduling = await _schedulingRepository.GetByIdAsync(command.Id);

            if (scheduling == null)
                return new GenericCommandResult(false, "Scheduling not found");

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