using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.CommandTests.SchedulingTests;

[TestClass]
public class CreateSchedulingTests
{
    private readonly CreateSchedulingCommandRequest _InvalidCommand = new CreateSchedulingCommandRequest(
        SchedulingTime: DateTime.Now,
        SchedulingStatus: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.Empty, Guid.Empty) }
        );
    private readonly CreateSchedulingCommandRequest _ValidCommand = new CreateSchedulingCommandRequest(
        SchedulingTime: DateTime.Now,
        SchedulingStatus: Enum.ESchedulingStatus.Accepted,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.NewGuid(), Guid.NewGuid()) }

        );
    private readonly CreateSchedulingCommandRequest _SchedulingTimeIsNotMinValue = new CreateSchedulingCommandRequest(
        SchedulingTime: DateTime.MinValue,
        SchedulingStatus: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.NewGuid(), Guid.NewGuid()) }
        );
    private readonly CreateSchedulingCommandRequest _ProfessionalIdEmpty = new CreateSchedulingCommandRequest(
        SchedulingTime: DateTime.Now,
        SchedulingStatus: Enum.ESchedulingStatus.Pending,
        ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.NewGuid(), Guid.Empty) }
        );
    private readonly CreateSchedulingCommandRequest _SeriviceEmpty = new CreateSchedulingCommandRequest(
    SchedulingTime: DateTime.Now,
    SchedulingStatus: Enum.ESchedulingStatus.Pending,
    ProfessionalService: new List<ProfessionalServiceJoint>() { new ProfessionalServiceJoint(Guid.Empty, Guid.NewGuid()) }
    );

    public CreateSchedulingTests()
    {
        _InvalidCommand.Validate();
        _ValidCommand.Validate();
        _SchedulingTimeIsNotMinValue.Validate();
        _ProfessionalIdEmpty.Validate();
        _SeriviceEmpty.Validate();
    }
    [TestMethod]
    public void Scheduling_Create_Fail()
    {
        Assert.AreEqual(_InvalidCommand.IsValid, false);
    }
    [TestMethod]
    public void Scheduling_Create_Success()
    {
        Assert.AreEqual(_ValidCommand.IsValid, true);
    }
    [TestMethod]
    public void Message_When_The_DateTime_Min_Value()
    {
        Assert.AreEqual(_SchedulingTimeIsNotMinValue.IsValid, false);
        Assert.AreEqual("adicione um horario correto para agendar", _SchedulingTimeIsNotMinValue.Notifications.FirstOrDefault()?.Message);
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
        Assert.AreEqual("Adicione um Servico", _SeriviceEmpty.Notifications.FirstOrDefault()?.Message);
    }
}

