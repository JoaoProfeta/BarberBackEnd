using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;
namespace Barber.Domain.Handler.ProfessionalHandle;

public class CreateProfessionalHandler : IHandler<CreateProfessionalCommandRequest>
{
    private readonly IProfessionalRepository _professonalRepository;
    public CreateProfessionalHandler(IProfessionalRepository professonalRepository)
    {
        _professonalRepository = professonalRepository;
    }
    public async Task<ICommandResult> Handle(CreateProfessionalCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Profissional Invalido");

            var professonal = new Professional(
                command.ProfessionalId,
                command.ProfessionalName,
                command.Status,
                command.Services
                );

            await _professonalRepository.CreateAsync(professonal);

            return new GenericCommandResult(true, "Profissional criado com sucesso",
                data: new
                {
                    professonal.Id,
                    professonal.ProfessionalId,
                    professonal.ProfessionalName,
                    professonal.Status,
                    professonal.Services
                });
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(false, "Erro ao criar profissional");
        }
    }
}

