using Barber.Domain.Command;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.ServiceHandle;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.HandleTests.ServiceHandleTests;

[TestClass]
public class DeleteServiceHandleTest
{
    private readonly DeleteServiceCommandRequest _InvalidCommand = new DeleteServiceCommandRequest(Id: Guid.NewGuid());
    private readonly DeleteServiceCommandRequest _ValidCommand;
    private readonly DeleteServiceHandle _handle;
    private readonly FakeServiceRepository _repository;
    private GenericCommandResult _result = new GenericCommandResult();
    public DeleteServiceHandleTest()
    {
        _repository = new FakeServiceRepository();
        _handle = new DeleteServiceHandle(_repository);
        var service = new Service(name: "João", status: Enum.EAvailabilityStatus.Avaliable);
        _ValidCommand = new DeleteServiceCommandRequest(Id: service.Id);
        _repository.CreateAsync(service).Wait();
    }
   // [TestMethod]
    public async Task Delete_Service_Handle_Test_Fail()
    {
        var result = await _handle.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
   // [TestMethod]
    public async Task Delete_Service_Handle_Test_Success()
    {
        var result = await _handle.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }

}


