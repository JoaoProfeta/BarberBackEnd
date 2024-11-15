using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler;

public class ServiceHandler :
    IHandler<CreateServiceCommandRequest>,
    IHandler<UpdateServiceCommandRequest>,
    IHandler<DeleteServiceCommandRequest>
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceHandler(IServiceRepository serviceRepository)
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

    public async Task<ICommandResult> Handle(UpdateServiceCommandRequest command)
    {
        
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao identificar Servico");
            
            var service = await _serviceRepository.GetByIdAsync(command.Id);

           if(command.Name != null)
                service.UpdateName(command.Name);

            if (command.Status != service.ServiceStatus)
                service.UpdateStatus(command.Status);
            
            
                
            await _serviceRepository.UpdateAsync(service);

            return new GenericCommandResult(true, "Servi�o atualizado com sucesso",
                data: new
                {
                    service.Name,
                    service.ServiceStatus
                });
        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Erro ao Atualizar Servi�o");
        }
    }

    public async Task<ICommandResult> Handle(DeleteServiceCommandRequest command)
    {
        try
        {
            if (command.Id.ToString().Length <= 0)
                return new GenericCommandResult(false, "Erro ao identificar Servi�o");

            var service = await _serviceRepository.GetByIdAsync(command.Id);

            if (service != null)
                await _serviceRepository.DeleteAsync(service);

            return new GenericCommandResult(true, "Servi�o deletado com sucesso");

        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Erro ao deletar servi�i");
        }
    }


}