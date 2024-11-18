using Barber.Domain.Command;
using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using Barber.Domain.Handler;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.HandleTests.ProfessionalHandleTests
{
    [TestClass]
    public class CreateProfessionalHandleTests
    {
        private readonly CreateProfessionalCommandRequest _InvalidCommand = new CreateProfessionalCommandRequest(
                ProfessionalId: Guid.NewGuid(),
                ProfessionalName: "",
                Status: Enum.EAvailabilityStatus.Avaliable,
                Services: new List<Service> { }
                );

        private readonly CreateProfessionalCommandRequest _ValidCommand = new CreateProfessionalCommandRequest(
                ProfessionalId: Guid.NewGuid(),
                ProfessionalName: "João",
                Status: Enum.EAvailabilityStatus.Avaliable,
                Services: new List<Service> { new Service(name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable) }
                );

        private readonly ProfessionalHandler _Handler = new ProfessionalHandler(new FakeProfessionalRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public async Task Create_Professional_Handle_Test_Fail()
        {
            var result = await _Handler.Handle(_InvalidCommand);
             _result = (GenericCommandResult)result;
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public async Task Create_Professional_Handle_Test_Success()
        {
            var result = await _Handler.Handle(_ValidCommand);
            _result = (GenericCommandResult)result;
            Assert.AreEqual(_result.Success, true);
        }

    }
}
