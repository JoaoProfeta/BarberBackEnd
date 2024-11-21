﻿using Barber.Domain.Command;
using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.SchedulingHandle;
using Barber.Domain.Tests.FakeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.HandleTests.SchedulingHandleTests;

[TestClass]
public class UpdateSchedulingHandleTests
{
    private readonly UpdateSchedulingCommandRequest _InvalidCommand;
    private readonly UpdateSchedulingCommandRequest _ValidCommand;
    private readonly UpdateSchedulingHandle _handle;
    private readonly FakeSchedulingRepository _repository;
    private GenericCommandResult _result = new GenericCommandResult();
    public UpdateSchedulingHandleTests()
    {
        _repository = new FakeSchedulingRepository();
        _handle = new UpdateSchedulingHandle(_repository);
        var professionalSelected = Guid.NewGuid();
        Scheduling create = new Scheduling(
                schedulingTime: DateTime.Now,
                professionalSelected,
                status: Enum.ESchedulingStatus.Rejected,
                servicesSelected: new List<Service> { new Service(name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable) }
                );
        _repository.CreateAsync(create).Wait();
        _InvalidCommand = new UpdateSchedulingCommandRequest(
            Id: Guid.NewGuid(),
            SchedulingTime: DateTime.Now,
            ProfessionalSelectedId: Guid.NewGuid(),
            Status: Enum.ESchedulingStatus.Pending,
            ServicesSelected: new List<Service>  { new Service(name: "Cabelo", status: Enum.EAvailabilityStatus.Unavailable)}
            );
        _ValidCommand = new UpdateSchedulingCommandRequest(
            Id: create.Id,
            SchedulingTime: DateTime.Now,
            ProfessionalSelectedId: Guid.NewGuid(),
            Status: Enum.ESchedulingStatus.Accepted,
            ServicesSelected: new List<Service> { new Service(name: "Cabelo", status: Enum.EAvailabilityStatus.Unavailable) }
            );
    }
    [TestMethod]
    public async Task Update_Scheduling_Handle_Test_Fail()
    {
        var result = await _handle.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
    [TestMethod]
    public async Task Update_Scheduling_Handle_Test_Success()
    {
        var result = await _handle.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }
}


