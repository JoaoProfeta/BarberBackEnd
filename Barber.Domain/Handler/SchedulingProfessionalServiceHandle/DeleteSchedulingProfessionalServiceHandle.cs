using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.SchedulingProfessionalServiceRequest;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.SchedulingProfessionalServiceHandle;

public class DeleteSchedulingProfessionalServiceHandle : IHandler<DeleteSchedulingProfessionalServiceCommandRequest>
{
	private readonly ISchedulingProfessionalServiceRepository _repository;
	public DeleteSchedulingProfessionalServiceHandle(ISchedulingProfessionalServiceRepository repository)
	{
		_repository = repository;
	}
	public async Task<ICommandResult> Handle(DeleteSchedulingProfessionalServiceCommandRequest command)
	{
		try
		{
			command.Validate();
			if (!command.IsValid)
				return new GenericCommandResult(false, "Erro ao validar command");
			var toDelete = await _repository.GetByIdAsync(command.Id);

			if (toDelete == null)
				return new GenericCommandResult(false, "Erro ao encontrar Agendamento");

			await _repository.DeleteAsync(toDelete);
			return new GenericCommandResult(true, "Sucesso ao atrelar profissional e servico ao agendamento");
		}
		catch (Exception ex)
		{
			return new GenericCommandResult(false, "Erro ao atrelar profissional e servico ao agendamento");
		}
	}
}

