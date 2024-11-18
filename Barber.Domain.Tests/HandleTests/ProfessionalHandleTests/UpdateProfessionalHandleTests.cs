using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Tests.FakeRepository;
using Barber.Domain.Command;
using Barber.Domain.Entity;
namespace Barber.Domain.Tests.HandleTests.ProfessionalHandleTests
{
    [TestClass]
    public class UpdateProfessionalHandleTests
    {
        private readonly UpdateProfessionalCommandRequest _InvalidCommand = new UpdateProfessionalCommandRequest(
            Id: Guid.NewGuid(),
            ProfessionalId: Guid.NewGuid(),
            ProfessionalName: "",
            Status: Enum.EAvailabilityStatus.Avaliable,
            Services: new List<Service> {  }
            );
        private readonly UpdateProfessionalCommandRequest _ValidCommand = new UpdateProfessionalCommandRequest(
            Id: Guid.NewGuid(),
            ProfessionalId: Guid.NewGuid(),
            ProfessionalName: "Vitor",
            Status: Enum.EAvailabilityStatus.Avaliable,
            Services: new List<Service> { new Service(name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable) }
            );
        private readonly FakeProfessionalRepository _repository;
        private readonly ProfessionalHandler _handler = new ProfessionalHandler(new FakeProfessionalRepository());
        private GenericCommandResult _result = new GenericCommandResult();


        public UpdateProfessionalHandleTests()
        {
            _repository = new FakeProfessionalRepository();
            _handler = new ProfessionalHandler(_repository); // Adiciona um profissional ao repositório falso para testes
            _repository.CreateAsync(new Professional( 
                userId: _ValidCommand.ProfessionalId, 
                professionalName: "Joao", 
                stats: Enum.EAvailabilityStatus.Available, 
                services: new List<Service> { new Service(name: "cabelo", status: Enum.EAvailabilityStatus.Available) } )).Wait();
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
}
