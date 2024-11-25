using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingProfessionalServiceRequest;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.SchedulingProfessionalServiceHandle;

public class UpdateSchedulingProfessionalServiceHandle : IHandler<UpdateSchedulingProfessionalServiceCommandRequest>
{
	private readonly ISchedulingProfessionalServiceRepository _repository;
	public UpdateSchedulingProfessionalServiceHandle(ISchedulingProfessionalServiceRepository repository)
	{
		_repository = repository;
	}
    public async Task<ICommandResult> Handle(UpdateSchedulingProfessionalServiceCommandRequest command)
    {
		try
		{
			command.Validate();
			if (!command.IsValid)
				return new GenericCommandResult(false, "Erro ao validar command");
			var toUpdate = await _repository.GetByIdAsync(command.Id);

			if (toUpdate == null)
				return new GenericCommandResult(false, "erro ao encontrar agendamento");

			await _repository.UpdateAsync(toUpdate);
			return new GenericCommandResult(true, "Sucesso ao atualiar agendamento");
		}
		catch (Exception)
		{
            return new GenericCommandResult(false, "Erro ao atualiar agendamento");
        }
    }
}

