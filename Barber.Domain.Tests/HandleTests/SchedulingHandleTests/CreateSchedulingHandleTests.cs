using Barber.Domain.Command;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.SchedulingHandle;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.HandleTests.SchedulingHandleTests;

[TestClass]
public class CreateSchedulingHandleTests
{
    private readonly CreateSchedulingCommandRequest _InvalidCommand = new CreateSchedulingCommandRequest(
        SchedulingTime: DateTime.Now,
        ProfessionalSelectedId: Guid.NewGuid(),
        SchedulingStatus: Enum.ESchedulingStatus.Pending,
        ServicesSelected: new List<Service>()
        );
    private readonly CreateSchedulingCommandRequest _ValidCommand = new CreateSchedulingCommandRequest(
        SchedulingTime: DateTime.Now,
        ProfessionalSelectedId: Guid.NewGuid(),
        SchedulingStatus: Enum.ESchedulingStatus.Pending,
        ServicesSelected: new List<Service> { new Service(name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable) }
        );
    private readonly CreateSchedulingHandler _Handler = new CreateSchedulingHandler(new FakeSchedulingRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    [TestMethod]
    public async Task Create_Scheduling_Handle_Test_fail()
    {
        var result = await _Handler.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
    [TestMethod]
    public async Task Create_Scheduling_Handle_Test_success()
    {
        var result = await _Handler.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }
}

