using Barber.Domain.Entity;

namespace Barber.Domain.Tests.QueryTests;

[TestClass]
public class SchedulingQueriesTest
{
    private readonly List<Scheduling> _scheduling = new();
    private List<Service> _services = new()
    {
        new Service(name: "Cabelo", status: Enum.EAvailabilityStatus.Avaliable),
        new Service(name: "Sobrancelha", status: Enum.EAvailabilityStatus.Avaliable),
        new Service(name: "Barba", status: Enum.EAvailabilityStatus.Avaliable),
        new Service(name: "Pezinho", status: Enum.EAvailabilityStatus.Avaliable),
    };
    private List<Professional> _professionals = new();

    private List<ProfessionalServiceJoint> _professionalService = new();
    private List<SchedulingProfessionalServiceJoint> _schedulingProfessionalServiceJoint = new();
    public SchedulingQueriesTest()
    {
        _professionals.Add(new Professional(
            userId: Guid.NewGuid(),
            professionalName: "João",
            stats: Enum.EAvailabilityStatus.Avaliable));

        _professionals.Add(new Professional(
            userId: Guid.NewGuid(),
            professionalName: "Vitor",
            stats: Enum.EAvailabilityStatus.Avaliable));

        _professionals.Add(new Professional(
            userId: Guid.NewGuid(),
            professionalName: "Vitor",
            stats: Enum.EAvailabilityStatus.Avaliable));

        _professionalService.Add(new ProfessionalServiceJoint(_services[0].Id, _professionals[0].Id));
        _professionalService.Add(new ProfessionalServiceJoint(_services[1].Id, _professionals[1].Id));
        _professionalService.Add(new ProfessionalServiceJoint(_services[2].Id, _professionals[2].Id));

        var scheduling1 = new Scheduling(DateTime.Now, Enum.ESchedulingStatus.Pending);
        var scheduling2 = new Scheduling(DateTime.Now, Enum.ESchedulingStatus.Pending);
        var scheduling3 = new Scheduling(DateTime.Now, Enum.ESchedulingStatus.Accepted);

        var joint1 = new SchedulingProfessionalServiceJoint(scheduling1.Id, _professionalService[0].Id);
        var joint2 = new SchedulingProfessionalServiceJoint(scheduling2.Id, _professionalService[1].Id);
        var joint3 = new SchedulingProfessionalServiceJoint(scheduling3.Id, _professionalService[2].Id);

        scheduling1.SchedulingProfessionalsServices.Add(joint1);
        scheduling2.SchedulingProfessionalsServices.Add(joint2);
        scheduling3.SchedulingProfessionalsServices.Add(joint3);

        _scheduling.Add(scheduling1);
        _scheduling.Add(scheduling2);
        _scheduling.Add(scheduling3);

    }

    [TestMethod]
    public void Scheduling_Query_Test_Get_All()
    {
        var scheduling = _scheduling.AsQueryable().Where(Queries.SchedulingQueries.GetAll());
        Assert.IsNotNull(scheduling);
        Assert.IsTrue(scheduling.Count() > 0);
    }
    [TestMethod]
    public void Scheduling_Query_Test_Get_By_Id()
    {
        var selectedScheduling = _scheduling[0];
        var scheduling = _scheduling.AsQueryable().Where(Queries.SchedulingQueries.GetById(_scheduling[0].Id));
        Assert.IsNotNull(scheduling);
        Assert.AreEqual(scheduling.FirstOrDefault().Id, selectedScheduling.Id);
    }
}