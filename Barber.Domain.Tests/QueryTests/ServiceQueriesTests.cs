using System.Runtime.InteropServices;
using Barber.Domain.Entity;

namespace Barber.Domain.Tests.QueryTests;

[TestClass]
public class ServiceQueriesTest
{
    private List<Service> _services = new()
    {
        new Service(name: "Cabelo", status: Enum.EAvailabilityStatus.Avaliable),
        new Service(name: "Sobrancelha", status: Enum.EAvailabilityStatus.Avaliable),
        new Service(name: "Barba", status: Enum.EAvailabilityStatus.Avaliable),
        new Service(name: "Pezinho", status: Enum.EAvailabilityStatus.Avaliable),
    };
    private List<Professional> _professionals = new();

    private List<ProfessionalServiceJoint> _professionalService = new();
    public ServiceQueriesTest()
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
    }
    [TestMethod]
    public void Service_Query_Test_Get_All()
    {
        List<Service> services = _services.AsQueryable().Where(Queries.ServiceQueries.GetAll()).ToList();
        var result = services;
        Assert.AreEqual(result.Count, 4);
    }
    [TestMethod]
    public void Service_Query_Test_Get_By_Id()
    {
        var service = _services[0];
        var result = _services.AsQueryable().Where(Queries.ServiceQueries.GetById(service.Id)).FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsTrue(result == service);
        Assert.AreEqual(service, result);
    }
    [TestMethod]
    public void Get_All_Service_By_Professional_Id()
    {
        var firstProfesional = _professionals[0];
        var secontProfessional = _professionals[1];
        foreach (var service in _services)
        {
            firstProfesional.AddService(service.Id);
            secontProfessional.AddService(service.Id);
        }
        var result = _services.AsQueryable().Where(Queries.ServiceQueries.GetAllServicesByProfessonalId(firstProfesional.Id));
        Assert.IsNotNull(result);
        foreach (var item in result)
        {
            Assert.IsTrue(item.Professionals.Any(x => x.ServiceId == item.Id));
        }
    }

}