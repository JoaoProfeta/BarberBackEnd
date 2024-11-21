using Barber.Domain.Command;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.ServiceHandle;
using Barber.Domain.Tests.FakeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.HandleTests.ServiceHandleTests;

[TestClass]
public class UpdateServiceHandleTest
{
    private readonly UpdateServiceCommandRequest _InvalidCommand = new UpdateServiceCommandRequest(
        Id: Guid.NewGuid(),
        Name: "",
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    private readonly UpdateServiceCommandRequest _ValidCommand;
    private readonly FakeServiceRepository _repository;
    private readonly UpdateServiceHandle _handle;
    private GenericCommandResult _result = new GenericCommandResult();
    public UpdateServiceHandleTest()
    {
        _repository = new FakeServiceRepository();
        _handle = new UpdateServiceHandle(_repository);
        var service = new Service(name: "Profeta", status: Enum.EAvailabilityStatus.Avaliable);
        _ValidCommand = new UpdateServiceCommandRequest(
            Id: service.Id,
            Name: "XURRASQUEIRA",
            Status: Enum.EAvailabilityStatus.Unavailable
            );
        _repository.CreateAsync(service).Wait();
    }

    [TestMethod]
    public async Task Update_Service_Handle_Test_Fail()
    {
        var result = await _handle.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
    [TestMethod]
    public async Task Update_Service_Handle_Test_Success()
    {
        var result = await _handle.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }

}


