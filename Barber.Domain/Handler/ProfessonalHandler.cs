using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;
using Flunt.Notifications;
using Flunt.Validations;
namespace Barber.Domain.Handler
{
    public class ProfessionalHandler :
        IHandler<CreateProfessionalCommandRequest>,
        IHandler<UpdateProfessionalCommandRequest>,
        IHandler<DeleteProfessionalCommandRequest>
    {
        private readonly IProfessonalRepository _professonalRepository;

        public ProfessionalHandler(IProfessonalRepository professonalRepository)
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
                    command.ProfessonalId,
                    command.ProfessonalName,
                    command.Status,
                    command.Services
                    );

                await _professonalRepository.CreateAsync(professonal);

                return new GenericCommandResult(true, "Profissional criado com sucesso",
                    data: new
                    {
                        professonal.Id,
                        professonal.ProfessonalId,
                        professonal.ProfessonalName,
                        professonal.Status,
                        professonal.Services
                    });
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro ao criar profissional");
            }
        }

        public async Task<ICommandResult> Handle(UpdateProfessionalCommandRequest command)
        {
            try
            {
                command.Validate();
                if (!command.IsValid)
                    return new GenericCommandResult(false, "Erro ao identificar profissional");

                var professional = await _professonalRepository.GetByIdAsync(command.Id);

                professional.UpdateProfessonalName(command.ProfessonalName);
                professional.UpdateStatus(command.Status);

                await _professonalRepository.UpdateAsync(professional);

                return new GenericCommandResult(
                    sucess: true,
                    message: "Profissional Atualizado com sucesso",
                    data: new
                    {
                        professional.Id,
                        professional.ProfessonalId,
                        professional.ProfessonalName,
                        professional.Status,
                        professional.Services
                    });
            }
            catch (Exception ex)
            {

                return new GenericCommandResult(false, "erro ao atualizar profissional");
            }
        }

        public async Task<ICommandResult> Handle(DeleteProfessionalCommandRequest command)
        {
            try
            {
                command.Validate();
                if(!command.IsValid)
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
}
