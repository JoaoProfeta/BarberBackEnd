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

public class DeleteServiceHandle : IHandler<DeleteServiceCommandRequest>
{
    private readonly IServiceRepository _serviceRepository;
    public DeleteServiceHandle(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
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

