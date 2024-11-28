using Barber.Domain.Command;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler.ProfessionalHandle;
using Barber.Domain.Tests.FakeRepository;
namespace Barber.Domain.Tests.HandleTests.ProfessionalHandleTests;

[TestClass]
public class UpdateProfessionalHandleTests
{
    private readonly UpdateProfessionalCommandRequest _InvalidCommand = new UpdateProfessionalCommandRequest(
        Id: Guid.NewGuid(),
        ProfessionalId: Guid.NewGuid(),
        ProfessionalName: "",
        Status: Enum.EAvailabilityStatus.Avaliable
        );
    private readonly UpdateProfessionalCommandRequest _ValidCommand = new UpdateProfessionalCommandRequest(
        Id: Guid.NewGuid(),
        ProfessionalId: Guid.NewGuid(),
        ProfessionalName: "Vitor",
        Status: Enum.EAvailabilityStatus.Avaliable
        );
    private readonly FakeProfessionalRepository _repository;
    private readonly UpdateProfessionalHandle _handler;
    private GenericCommandResult _result = new GenericCommandResult();
    public UpdateProfessionalHandleTests()
    {
        _repository = new FakeProfessionalRepository();
        _handler = new UpdateProfessionalHandle(_repository); // Adiciona um profissional ao repositório falso para testes
        _repository.CreateAsync(new Professional(
            userId: _ValidCommand.ProfessionalId,
            professionalName: "Joao",
            stats: Enum.EAvailabilityStatus.Avaliable
           ));
    }

    [TestMethod]
    public async Task Update_Professional_Handle_Test_Fail()
    {

        var result = await _handler.Handle(_InvalidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, false);

    }
    [TestMethod]
    public async Task Update_Professional_Handle_Test_Success()
    {
        var result = await _handler.Handle(_ValidCommand);
        _result = (GenericCommandResult)result;
        Assert.AreEqual(_result.Success, true);
    }
}

