using Barber.Domain.Command.Request.ProfessonalRequests;
using Barber.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.EntityTests
{
    [TestClass]
    internal class ProfessonalTests
    {
        [TestMethod]
        public void Professonal_Create_Fail()
        {

            ICollection<Service> service;
            Guid id = Guid.NewGuid();
            var command = new CreateProfessonalCommandRequest(
               ProfessonalId: id,
               ProfessonalName: "",
               Status: Enum.EAvailabilityStatus.Avaliable,
               Services: []
                );





        }
        public void Professonal_Create_Valid()
        {

            ICollection<Service> service;
            Guid id = Guid.NewGuid();
            var command = new CreateProfessonalCommandRequest(
               ProfessonalId: id,
               ProfessonalName: "Joao Vitor",
               Status: Enum.EAvailabilityStatus.Avaliable,
               Services: [
                   new Service(
                       name: "sobrancelha",
                       status: Enum.EAvailabilityStatus.Unavailable
                       )
                   ]
                );
            command.Validate();
           

            Assert.AreEqual(command.Valid, false);
        }
    }
}
