using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler
{
    public class ProfessonalHandler :
        IHandler<CreateProfessonalCommandRequest>,
        IHandler<UpdateProfessonalCommandRequest>,
        IHandler<DeleteProfessonalCommandRequest>
    {
        private readonly IProfessonalRepository _professonalRepository;

        public ProfessonalHandler(IProfessonalRepository professonalRepository)
        {
            _professonalRepository = professonalRepository;
        }

        public async Task<ICommandResult> Handle(CreateProfessonalCommandRequest command)
        {
            try
            {
                if (command == null)
                    return new GenericCommandResult(false, "Professional Invalido");

                var professonal = new Professonals(
                    command.ProfessonalId,
                    command.ProfessonalName,
                    command.Stats,
                    command.Services
                    );

                await _professonalRepository.CreateAsync(professonal);

                return new GenericCommandResult(true, "Profissional criado com sucesso",
                    data: new
                    {
                        professonal.Id,
                        professonal.ProfessonalId,
                        professonal.ProfessonalName,
                        professonal.Stats,
                        professonal.Services
                    });




            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, "Erro ao criar profissional");
            }
        }

        public async Task<ICommandResult> Handle(UpdateProfessonalCommandRequest command)
        {
            try
            {
                if (command.Id.ToString().Length <= 0)
                    return new GenericCommandResult(false, "Erro ao identificar profissional");

                var professonal = await _professonalRepository.GetByIdAsync(command.Id);

                professonal.UpdateProfessonal(
                    command.ProfessonalId,
                    command.ProfessonalName,
                    command.Stats,
                    command.Services
                    );

                await _professonalRepository.UpdateAsync(professonal);

                return new GenericCommandResult(
                    sucess: true,
                    message: "Profissional Atualizado com sucesso",
                    data: new
                    {
                        professonal.Id,
                        professonal.ProfessonalId,
                        professonal.ProfessonalName,
                        professonal.Stats,
                        professonal.Services
                    });
            }
            catch (Exception ex)
            {

                return new GenericCommandResult(false, "erro ao atualizar profissional");
            }


        }

        public async Task<ICommandResult> Handle(DeleteProfessonalCommandRequest command)
        {
            try
            {
                if (command.Id.ToString().Length <= 0)
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
