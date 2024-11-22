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
    private readonly CreateServiceCommandRequest _EmptyName = new CreateServiceCommandRequest(
        Name: string.Empty,
        Status: Enum.EAvailabilityStatus.Unavailable
    );

    private readonly CreateServiceCommandRequest _NameLessThanThreeCharacters = new CreateServiceCommandRequest(
        Name: "JO",
        Status: Enum.EAvailabilityStatus.Avaliable
            );
    public CreateServiceTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
        _EmptyName.Validate();
        _NameLessThanThreeCharacters.Validate();
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
}

