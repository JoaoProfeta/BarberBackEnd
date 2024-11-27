using Barber.Domain.Command;
using Barber.Domain.Command.Request.ServicesRequests;
using Barber.Domain.Handler.ServiceHandle;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.HandleTests.ServiceHandleTests;

[TestClass]
public class CreateServiceHandleTest
{
    private readonly CreateServiceCommandRequest _InvalidCommand = new CreateServiceCommandRequest(
        Name: string.Empty,
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    private readonly CreateServiceCommandRequest _ValidCommand = new CreateServiceCommandRequest(
        Name: "João",
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    private readonly CreateServiceHandler _handle = new CreateServiceHandler(new FakeServiceRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    //[TestMethod]
    public async Task Create_Service_Handle_Test_Fail()
    {
        var result = await _handle.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
    //[TestMethod]
    public async Task Create_Service_Handle_Test_Success()
    {
        var result = await _handle.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }

}

