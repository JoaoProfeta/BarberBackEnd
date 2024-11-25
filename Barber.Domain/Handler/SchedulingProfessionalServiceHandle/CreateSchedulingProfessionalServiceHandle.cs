using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingProfessionalServiceRequest;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.SchedulingProfessionalServiceHandle;

public class CreateSchedulingProfessionalServiceHandle : IHandler<CreateSchedulingProfessionalServiceCommandRequest>
{
    private readonly ISchedulingProfessionalServiceRepository _repository;
    public CreateSchedulingProfessionalServiceHandle(ISchedulingProfessionalServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICommandResult> Handle(CreateSchedulingProfessionalServiceCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao validar command");

            var schedulingProfessionalService = new SchedulingProfessionalServiceJoint(command.SchedulingId, command.ProfessionalServiceId);

            await _repository.CreateAync(schedulingProfessionalService);

            return new GenericCommandResult(true, "Sucesso ao atrelar servicos e profissionais ao agendamento");
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(false, "Erro ao atrelar servicos e profissionais ao agendamento");
        }
    }
}

