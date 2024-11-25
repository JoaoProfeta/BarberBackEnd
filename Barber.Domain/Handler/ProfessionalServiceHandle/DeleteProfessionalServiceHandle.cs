
using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessionalServiceRequest;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;
using System.Net.Http.Headers;

namespace Barber.Domain.Handler.ProfessionalServiceHandle;

public class DeleteProfessionalServiceHandle : IHandler<DeleteProfessionalServiceCommandRequest>
{
	private readonly IProfessionalServiceRepository _professionalServiceRepository;
	public DeleteProfessionalServiceHandle(IProfessionalServiceRepository professionalServiceRepository)
	{
		_professionalServiceRepository = professionalServiceRepository;
	}
    public async Task<ICommandResult> Handle(DeleteProfessionalServiceCommandRequest command)
    {
		try
		{
			command.Validate();
			if (!command.IsValid)
				return new GenericCommandResult(false, "Erro ao validar comando");

			var professionalService = await _professionalServiceRepository.GetByIdAsync(command.Id);

			if (professionalService == null)
				return new GenericCommandResult(false, "Erro ao encontrar serviço");

			await _professionalServiceRepository.DeleteAsync(professionalService);

			return new GenericCommandResult(true, "Sucesso ao deletar professionalService");
		}
		catch (Exception ex )
		{
			return new GenericCommandResult(false, "Erro ao deleter ProfessionalService");
		}
    }
}

