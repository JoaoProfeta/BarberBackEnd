using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.ServiceHandle;

public class CreateServiceHandler : IHandler<CreateServiceCommandRequestS
{
    private readonly IServiceRepository _serviceRepository;
    public CreateServiceHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    public async Task<ICommandResult> Handle(CreateServiceCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao criar serviço");

            var service = new Service(command.Name, command.Status);

            await _serviceRepository.CreateAsync(service);

            return new GenericCommandResult(true, "Servi�o Criado com sucesso",
                data: new
                {
                    command.Name,
                    command.Status,
                });
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(true, "Erro ao criar servi�o");
        }
    }
}