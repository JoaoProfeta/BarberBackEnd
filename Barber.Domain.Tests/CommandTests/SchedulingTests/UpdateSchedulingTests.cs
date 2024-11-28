using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.CommandTests.SchedulingTests;

[TestClass]
public class UpdateSchedulingTests
{
    private readonly UpdateSchedulingCommandRequest _InvalidCommand = new UpdateSchedulingCommandRequest(
        Id: Guid.NewGuid(),
        SchedulingTime: DateTime.Now,
        Status: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.Empty, Guid.Empty) }
        );
    private readonly UpdateSchedulingCommandRequest _ValidCommand = new UpdateSchedulingCommandRequest(
        Id: Guid.NewGuid(),
        SchedulingTime: DateTime.Now,
        Status: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.NewGuid(), Guid.NewGuid()) }
        );

    private readonly UpdateSchedulingCommandRequest _IdEmpty = new UpdateSchedulingCommandRequest(
        Id: Guid.Empty,
        SchedulingTime: DateTime.Now,
        Status: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.NewGuid(), Guid.NewGuid()) }
        );
    private readonly UpdateSchedulingCommandRequest _SchedulingTimeIsNotMinValue = new UpdateSchedulingCommandRequest(
        Id: Guid.NewGuid(),
        SchedulingTime: DateTime.MinValue,
        Status: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.Empty, Guid.Empty) }

        );
    private readonly UpdateSchedulingCommandRequest _ProfessionalIdEmpty = new UpdateSchedulingCommandRequest(
        Id: Guid.NewGuid(),
        SchedulingTime: DateTime.Now,
        Status: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.NewGuid(), Guid.Empty) }
        );
    private readonly UpdateSchedulingCommandRequest _SeriviceEmpty = new UpdateSchedulingCommandRequest(
    Id: Guid.NewGuid(),
    SchedulingTime: DateTime.Now,
    Status: Enum.ESchedulingStatus.Pending,
    ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.Empty, Guid.NewGuid()) }
    );
    public UpdateSchedulingTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
        _IdEmpty.Validate();
        _SchedulingTimeIsNotMinValue.Validate();
        _ProfessionalIdEmpty.Validate();
        _SeriviceEmpty.Validate();
    }
    [TestMethod]
    public void Update_Scheduling_Test_Fail()
    {
        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    [TestMethod]
    public void Update_Scheduling_Test_Success()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
    [TestMethod]
    public void Message_When_The_Id_Is_Empty()
    {
        Assert.AreEqual(_IdEmpty.IsValid, false);
        Assert.AreEqual("Id nao pode estar vazio", _IdEmpty.Notifications.FirstOrDefault()?.Message);
    }
    [TestMethod]
    public void Message_When_The_DateTime_Min_Value()
    {
        Assert.AreEqual(_SchedulingTimeIsNotMinValue.IsValid, false);
        Assert.AreEqual("Adicione um horario correto para agendar", _SchedulingTimeIsNotMinValue.Notifications.FirstOrDefault()?.Message);
    }
    [TestMethod]
    public void Message_When_The_Professional_Id_Is_Empty()
    {
        Assert.AreEqual(_ProfessionalIdEmpty.IsValid, false);
        Assert.AreEqual("Adicione um servico e um profissional", _ProfessionalIdEmpty.Notifications.FirstOrDefault()?.Message);
    }
    [TestMethod]
    public void Message_When_Service_Is_Empty()
    {
        Assert.IsFalse(_SeriviceEmpty.IsValid, "lista Serviço deve ser falsa quando estiver vazia");
        Assert.AreEqual("Adicione um servico e um profissional", _SeriviceEmpty.Notifications.FirstOrDefault()?.Message);
    }
}

