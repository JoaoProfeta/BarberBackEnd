using Barber.Domain.Command;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.SchedulingHandle;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.HandleTests.SchedulingHandleTests;

[TestClass]
public class DeleteSchedulingHandleTest
{
    private readonly DeleteSchedulingCommandRequest _InvalidCommand;
    private readonly DeleteSchedulingCommandRequest _ValidCommand;
    private readonly FakeSchedulingRepository _repository;
    private readonly DeleteSchedulingHandle _handle;
    private GenericCommandResult _result = new GenericCommandResult();

    public DeleteSchedulingHandleTest()
    {
        _repository = new FakeSchedulingRepository();
        _handle = new DeleteSchedulingHandle(_repository);
        Scheduling create = new Scheduling(
                schedulingTime: DateTime.Now,
                status: Enum.ESchedulingStatus.Accepted
                );
        _InvalidCommand = new DeleteSchedulingCommandRequest(Id: Guid.NewGuid());
        _ValidCommand = new DeleteSchedulingCommandRequest(Id: create.Id);
        _repository.CreateAsync(create).Wait();
    }

    //[TestMethod]
    public async Task Delete_Scheduling_Handle_Test_Fail()
    {
        var result = await _handle.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
    //[TestMethod]
    public async Task Delete_Scheduling_Handle_Test_Success()
    {
        var result = await _handle.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }

}

