using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;

namespace Barber.Domain.Tests.CommandTests.ProfessionalTests;

[TestClass]
public class CreateProfessionalTests
{
    private readonly CreateProfessionalCommandRequest _InvalidCommand = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "",
           Status: Enum.EAvailabilityStatus.Avaliable,
           Services: new List<Service> { new Service(name: "", status: Enum.EAvailabilityStatus.Avaliable) }
            );
    private readonly CreateProfessionalCommandRequest _ValidCommand = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "Joao Vitor",
           Status: Enum.EAvailabilityStatus.Avaliable,
           Services: new List<Service>{
                   new Service(  name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable )}
            );
    public CreateProfessionalTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
    }
    [TestMethod]
    public void Professional_Create_Fail()
    {

        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    [TestMethod]
    public void Professional_Create_Valid()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
}

