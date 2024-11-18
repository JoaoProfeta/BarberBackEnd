using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.ProfessionalHandle;

public class UpdateProfessionalHandle : IHandler<UpdateProfessionalCommandRequest>
{
    private readonly IProfessionalRepository _professonalRepository;

    public UpdateProfessionalHandle(IProfessionalRepository professonalRepository)
    {
        _professonalRepository = professonalRepository;
    }
    public async Task<ICommandResult> Handle(UpdateProfessionalCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao identificar profissional");

            var professional = await _professonalRepository.GetByIdAsync(command.ProfessionalId);
            professional.UpdateProfessonalName(command.ProfessionalName);
            professional.UpdateStatus(command.Status);

            await _professonalRepository.UpdateAsync(professional);

            return new GenericCommandResult(
                sucess: true,
                message: "Profissional Atualizado com sucesso",
                data: new
                {
                    professional.Id,
                    professional.ProfessionalId,
                    professional.ProfessionalName,
                    professional.Status,
                    professional.Services
                });
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(false, "erro ao atualizar profissional");
        }
    }
}

