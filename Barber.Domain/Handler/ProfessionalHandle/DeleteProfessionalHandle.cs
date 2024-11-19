using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.ProfessionalHandle;

public class DeleteProfessionalHandle : IHandler<DeleteProfessionalCommandRequest>
{
    private readonly IProfessionalRepository _professonalRepository;

    public DeleteProfessionalHandle(IProfessionalRepository professonalRepository)
    {
        _professonalRepository = professonalRepository;
    }
    public async Task<ICommandResult> Handle(DeleteProfessionalCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao encontrar profissional");

            var professonal = await _professonalRepository.GetByIdAsync(command.Id);

            await _professonalRepository.DeleteAsync(professonal);

            return new GenericCommandResult(true, "Sucesso ao deletar Profissional");
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(true, "Erro ao deletar Profissional");
        }
    }
}

