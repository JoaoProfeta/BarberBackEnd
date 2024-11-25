using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessionalServiceRequest;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.ProfessionalServiceHandle;

public class CreateProfessionalServiceHandle : IHandler<CreateProfessionalServiceCommandRequest>
{
	private readonly IProfessionalServiceRepository _repository;
	private CreateProfessionalServiceHandle(IProfessionalServiceRepository professionalServiceRepository)
	{
		_repository = professionalServiceRepository;
	}
	public async Task<ICommandResult> Handle(CreateProfessionalServiceCommandRequest command)
	{
		try
		{
			command.Validate();
			if (command.IsValid)
				return new GenericCommandResult(false, "Professionao or service invalid");

			var professionalService = new ProfessionalServiceJoint(command.ServiceId, command.ProfessionalId);

			if (professionalService == null)
				return new GenericCommandResult(false, "Erro ao criar ProfessionalService");

			await _repository.CreateAync(professionalService);

			return new GenericCommandResult(true, "Sucesso ao atrelar servico ao profissional",
				data: new
				{
					professionalService.ServiceId,
					professionalService.ProfessionalId
				});
		}
		catch (Exception ex)
		{

			return new GenericCommandResult(false, "Erro ao atrelar servico ao profissional");
		}
	}
}

