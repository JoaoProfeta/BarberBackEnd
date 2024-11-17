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
    public class UpdateSchedulingTests
    {
        private readonly UpdateSchedulingCommandRequest _InvalidCommand = new UpdateSchedulingCommandRequest(
            Id: Guid.NewGuid(),
            SchedulingTime: DateTime.Now,
            ProfessionalSelectedId: Guid.NewGuid(),
            Status:Enum.ESchedulingStatus.Pending,
            ServicesSelected: new List<Service> { }
            );
        private readonly UpdateSchedulingCommandRequest _ValidCommand = new UpdateSchedulingCommandRequest(
            Id: Guid.NewGuid(),
            SchedulingTime: DateTime.Now,
            ProfessionalSelectedId: Guid.NewGuid(),
            Status: Enum.ESchedulingStatus.Pending,
            ServicesSelected: new List<Service> { new Service(name: "sobrancelha", status: Enum.EAvailabilityStatus.Unavailable) }
            );
        
        public UpdateSchedulingTests() 
        { 
            _InvalidCommand.Validate();
            _ValidCommand.Validate();
        }
        [TestMethod]
        public void Update_Scheduling_Test_Fail()
        {
            Assert.AreEqual(_InvalidCommand.IsValid, false);
        }
        [TestMethod]
        public void Update_Scheduling_Test_Success()
        {
            Assert.AreEqual( _ValidCommand.IsValid, true);
        }
    }
}
