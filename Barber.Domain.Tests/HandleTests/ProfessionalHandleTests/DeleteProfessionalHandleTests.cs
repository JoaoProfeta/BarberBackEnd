using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Command;
using Barber.Domain.Entity;
using Barber.Domain.Handler.ProfessionalHandle;
using Barber.Domain.Tests.FakeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.HandleTests.ProfessionalHandleTests;

[TestClass]
public class DeleteProfessionalHandleTests
{
    private readonly DeleteProfessionalCommandRequest _InvalidCommand = new DeleteProfessionalCommandRequest(Id: Guid.NewGuid());
    private readonly DeleteProfessionalCommandRequest _ValidCommand;
    private readonly FakeProfessionalRepository _repository;
    private readonly DeleteProfessionalHandle _handler;
    private GenericCommandResult _result = new GenericCommandResult();

    public DeleteProfessionalHandleTests()
    {
        _repository = new FakeProfessionalRepository();
        var validProfessionalId = Guid.NewGuid();
        _ValidCommand = new DeleteProfessionalCommandRequest(Id: validProfessionalId);
        _handler = new DeleteProfessionalHandle(_repository); // Adiciona um profissional ao repositório falso para testes
        _repository.CreateAsync(new Professional(
            userId: _ValidCommand.Id,
            professionalName: "PROFETINHA",
            stats: Enum.EAvailabilityStatus.Available,
            services: new List<Service> { new Service(name: "Barba", status: Enum.EAvailabilityStatus.Available) }
            )).Wait();
    }

    [TestMethod]
    public async Task Delete_Professional_Handle_Fail()
    {
        var result = await _handler.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);
    }
    [TestMethod]
    public async Task Delete_Professional_Handle_Success()
    {
        var result = await _handler.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }
}

