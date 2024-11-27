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
    private readonly UpdateServiceCommandRequest _IdEmpty = new UpdateServiceCommandRequest(
        Id: Guid.Empty,
        Name: "Joao",
        Status: Enum.EAvailabilityStatus.Avaliable
        );
    private readonly UpdateServiceCommandRequest _EmptyName = new UpdateServiceCommandRequest(
        Id: Guid.NewGuid(),
        Name: string.Empty,
        Status: Enum.EAvailabilityStatus.Unavailable
        );

    private readonly UpdateServiceCommandRequest _NameLessThanThreeCharacters = new UpdateServiceCommandRequest(
        Id: Guid.NewGuid(),
        Name: "JO",
        Status: Enum.EAvailabilityStatus.Avaliable
        );
    public UpdateServiceTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
        _EmptyName.Validate();
        _NameLessThanThreeCharacters.Validate();
        _IdEmpty.Validate();
    }
    //[TestMethod]
    public void Update_Service_Test_Fail()
    {
        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    //[TestMethod]
    public void Update_Service_Test_Success()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
    //[TestMethod]
    public void Message_When_The_Id_Is_Empty()
    {
        Assert.AreEqual(_IdEmpty.IsValid, false);
        Assert.AreEqual("Id nao pode estar vazio", _IdEmpty.Notifications.FirstOrDefault()?.Message);
    }
    //[TestMethod]
    public void Message_When_The_Name_Is_Empty()
    {
        Assert.AreEqual(_EmptyName.IsValid, false);
        Assert.AreEqual("O nome nao pode ser vazio", _EmptyName.Notifications.FirstOrDefault()?.Message);
    }
    //[TestMethod]
    public void Message_When_Name_Contains_Less_than_3_characters()
    {
        Assert.AreEqual(_NameLessThanThreeCharacters.IsValid, false);
        Assert.AreEqual("Nome deve conter no minimo 3 caracteres", _NameLessThanThreeCharacters.Notifications.FirstOrDefault()?.Message);
    }
}

