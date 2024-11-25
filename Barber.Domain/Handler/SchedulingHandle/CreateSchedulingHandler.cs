using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.SchedulingHandle;

public class CreateSchedulingHandler : IHandler<CreateSchedulingCommandRequest>
{
    private readonly ISchedulingRepository _schedulingRepository;
    public CreateSchedulingHandler(ISchedulingRepository schedulingRepository)
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
               command.SchedulingStatus
               );

            foreach (var item in command.ProfessionalService)
            {
                scheduling.AddProfessionalService(scheduling.Id, item.Id);
            }

            await _schedulingRepository.CreateAsync(scheduling);

            return new GenericCommandResult(
                sucess: true,
                message: "Schuling Created",
                data: new
                {
                    scheduling.Id,
                    scheduling.SchedulingTime,
                    scheduling.SchedulingStatus,
                }
             );
        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Falha ao agendar");
        }

    }




}