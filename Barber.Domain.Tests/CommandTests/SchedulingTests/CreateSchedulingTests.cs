using Barber.Domain.Command.Request.SchedulingRequests;
using Barber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.CommandTests.SchedulingTests
{
    [TestClass]
    public class CreateSchedulingTests
    {
        private readonly CreateSchedulingCommandRequest _InvalidCommand = new CreateSchedulingCommandRequest(
            SchedulingTime: DateTime.Now,
            ProfessionalSelectedId: Guid.NewGuid(),
            SchedulingStatus: Enum.ESchedulingStatus.Pending,
            ServicesSelected: new List<Service>()
            );
        private readonly CreateSchedulingCommandRequest _ValidCommand = new CreateSchedulingCommandRequest(
            SchedulingTime: DateTime.Now,
            ProfessionalSelectedId: Guid.NewGuid(),
            SchedulingStatus: Enum.ESchedulingStatus.Accepted,
            ServicesSelected: new List<Service> {
                new Service("Sobrancelha", status: Enum.EAvailabilityStatus.Avaliable),
                new Service("Cabelo", status: Enum.EAvailabilityStatus.Unavailable)
            }
            );

        public CreateSchedulingTests()
        {
            _InvalidCommand.Validate();
            _ValidCommand.Validate();
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
    }
}
