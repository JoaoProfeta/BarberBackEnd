using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.CommandTests.ProfessionalTests;

[TestClass]
public class UpdateProfessionalTests
{
    private readonly UpdateProfessionalCommandRequest _InvalidCommand = new UpdateProfessionalCommandRequest(
        Id: Guid.NewGuid(),
        ProfessionalId: Guid.NewGuid(),
        ProfessionalName: "",
        Status: Enum.EAvailabilityStatus.Unavailable,
        Services: new List<Service> { new Service(name: "Sobrancelha", status: Enum.EAvailabilityStatus.Avaliable) }
        );
    private readonly UpdateProfessionalCommandRequest _ValidCommand = new UpdateProfessionalCommandRequest(
        Id: Guid.NewGuid(),
        ProfessionalId: Guid.NewGuid(),
        ProfessionalName: "Joao Vitor",
        Status: Enum.EAvailabilityStatus.Unavailable,
        Services: new List<Service> { new Service(name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable) }
        );
    public UpdateProfessionalTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
    }
    [TestMethod]
    public void Update_Professional_Test_Fail()
    {
        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    [TestMethod]
    public void Update_Professional_Test_Success()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
}

