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
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    private readonly UpdateProfessionalCommandRequest _ValidCommand = new UpdateProfessionalCommandRequest(
        Id: Guid.NewGuid(),
        ProfessionalId: Guid.NewGuid(),
        ProfessionalName: "Joao Vitor",
        Status: Enum.EAvailabilityStatus.Unavailable
        );
    private readonly UpdateProfessionalCommandRequest _EmptyName = new UpdateProfessionalCommandRequest(
           Id: Guid.NewGuid(),
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: string.Empty,
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly UpdateProfessionalCommandRequest _NameLessThanThreeCharacters = new UpdateProfessionalCommandRequest(
           Id: Guid.NewGuid(),
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "JO",
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly UpdateProfessionalCommandRequest _IdEmpty = new UpdateProfessionalCommandRequest(
           Id: Guid.Empty,
           ProfessionalId: Guid.NewGuid(),
           ProfessionalName: "JOAO",
           Status: Enum.EAvailabilityStatus.Avaliable
            );
    private readonly UpdateProfessionalCommandRequest _ProfessionalIdEmpty = new UpdateProfessionalCommandRequest(
           Id: Guid.NewGuid(),
           ProfessionalId: Guid.Empty,
           ProfessionalName: "JOAO",
           Status: Enum.EAvailabilityStatus.Avaliable
            );

    public UpdateProfessionalTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
        _EmptyName.Validate();
        _NameLessThanThreeCharacters.Validate();
        _IdEmpty.Validate();
        _ProfessionalIdEmpty.Validate();
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
    public void Message_When_The_Id_Is_Empty()
    {
        Assert.AreEqual(_IdEmpty.IsValid, false);
        Assert.AreEqual("Id nao pode estar vazio", _IdEmpty.Notifications.FirstOrDefault()?.Message);

    }
    [TestMethod]
    public void Message_When_The_Professional_Id_Is_Empty()
    {
        Assert.AreEqual(_ProfessionalIdEmpty.IsValid, false);
        Assert.AreEqual("Id do profissional Nao pode estar vazio", _ProfessionalIdEmpty.Notifications.FirstOrDefault()?.Message);
    }
}

