using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Command;
using Barber.Domain.Command.Contracts;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Handler.Contracts;
using Barber.Domain.Repository;

namespace Barber.Domain.Handler.ServiceHandle;

public class UpdateServiceHandle : IHandler<UpdateServiceCommandRequest>
{
    private readonly IServiceRepository _serviceRepository;
    public UpdateServiceHandle(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    public async Task<ICommandResult> Handle(UpdateServiceCommandRequest command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Erro ao identificar Servico");

            var service = await _serviceRepository.GetByIdAsync(command.Id);

            if (command.Name != null)
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
}

