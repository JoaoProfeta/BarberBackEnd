using Barber.Domain.Command.Request.ServicesRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.CommandTests.ServiceTests;

[TestClass]
public class CreateServiceTests
{
    private readonly CreateServiceCommandRequest _InvalidCommand = new CreateServiceCommandRequest(
        Name: "",
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    private readonly CreateServiceCommandRequest _ValidCommand = new CreateServiceCommandRequest(
        Name: "João Vitor",
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    public CreateServiceTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
    }
    [TestMethod]
    public void Service_Create_Invalid()
    {
        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    [TestMethod]
    public void Service_Create_Valid()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
}

