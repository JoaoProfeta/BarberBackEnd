using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Command.Response;
using Barber.Domain.Entity;
using Barber.Domain.Enum;
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
            var service = new Services(command.Name, command.Status);

            await _serviceRepository.CreateAsync(service);

            return new GenericCommandResult(true, "Serviço Criado com sucesso",
                data: new
                {
                    command.Name,
                    command.Status,
                });
        }
        catch (Exception ex)
        {

            return new GenericCommandResult(true, "Erro ao criar serviço");
        }
    }

    public async Task<ICommandResult> Handle(UpdateServiceCommandRequest command)
    {
        try
        {
            if(command.Id.ToString().Length <= 0)
                return new GenericCommandResult(false, "Erro ao identificar Serviço");

            var service = await _serviceRepository.GetByIdAsync(command.Id);

            if(service != null)
                service.UpdateService(
                    name: command.Name,
                    stats: command.Status
                    );

            await _serviceRepository.UpdateAsync(service);

            return new GenericCommandResult(true, "Serviço atualizado com sucesso", 
                data : new
                {
                    service.Name,
                    service.ServiceStatus
                });
        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Erro ao Atualizar Serviço");
        }
    }

    public async Task<ICommandResult> Handle(DeleteServiceCommandRequest command)
    {
        try
        {
            if(command.Id.ToString().Length <= 0)
                return new GenericCommandResult(false, "Erro ao identificar Serviço");
            
            var service = await _serviceRepository.GetByIdAsync(command.Id);

            if (service != null)
                await _serviceRepository.DeleteAsync(service);

            return new GenericCommandResult(true, "Serviço deletado com sucesso");

        }
        catch (Exception ex)
        {

            return new GenericCommandResult(false, "Erro ao deletar serviçi");
        }
    }


}