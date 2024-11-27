using Barber.Domain.Command;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.ProfessionalHandle;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.CommandTests.ProfessionalTests;

[TestClass]
public class CreateProfessionalTests
{
    private readonly CreateProfessionalCommandRequest _InvalidCommand = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "",
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly CreateProfessionalCommandRequest _ValidCommand = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "Joao Vitor",
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly CreateProfessionalCommandRequest _EmptyName = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: string.Empty,
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly CreateProfessionalCommandRequest _NameLessThanThreeCharacters = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "JO",
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly CreateProfessionalCommandRequest _ProfessionalIdEmpty = new CreateProfessionalCommandRequest(
           ProfessionalId: Guid.Empty,
           ProfessionalName: "JOAO",
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    public CreateProfessionalTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
        _EmptyName.Validate();
        _NameLessThanThreeCharacters.Validate();
        _ProfessionalIdEmpty.Validate();
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
    [TestMethod]
    public void Message_When_The_Name_Is_Empty()
    {
        Assert.AreEqual(_EmptyName.IsValid, false);
        Assert.AreEqual("O nome nao pode ser vazio", _EmptyName.Notifications.FirstOrDefault()?.Message);
    }
    [TestMethod]
    public void Message_When_Name_Contains_Less_than_3_characters()
    {
        Assert.AreEqual(_NameLessThanThreeCharacters.IsValid, false);
        Assert.AreEqual("Nome deve conter no minimo 3 caracteres", _NameLessThanThreeCharacters.Notifications.FirstOrDefault()?.Message);
    }
    [TestMethod]
    public void Message_When_The_Professional_Id_Is_Empty()
    {
        Assert.AreEqual(_ProfessionalIdEmpty.IsValid, false);
        Assert.AreEqual("Id do profissional Nao pode estar vazio", _ProfessionalIdEmpty.Notifications.FirstOrDefault()?.Message);
    }
}

