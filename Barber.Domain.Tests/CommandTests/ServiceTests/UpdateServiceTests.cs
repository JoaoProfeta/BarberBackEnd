using Barber.Domain.Command.Request.ServicesRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.CommandTests.ServiceTests;

[TestClass]
public class UpdateServiceTests
{
    private readonly UpdateServiceCommandRequest _InvalidCommand = new UpdateServiceCommandRequest(
        Id: Guid.NewGuid(),
        Name: "",
        Status: Enum.EAvailabilityStatus.Avaliable
        );
    private readonly UpdateServiceCommandRequest _ValidCommand = new UpdateServiceCommandRequest(
        Id: Guid.NewGuid(),
        Name: "Cabelo",
        Status: Enum.EAvailabilityStatus.Avaliable
        );
    public UpdateServiceTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
    }
    [TestMethod]
    public void Update_Service_Test_Fail()
    {
        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    [TestMethod]
    public void Update_Service_Test_Success()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
}

