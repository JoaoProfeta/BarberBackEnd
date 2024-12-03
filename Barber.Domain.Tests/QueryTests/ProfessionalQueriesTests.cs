using Barber.Domain.Entity;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.QueryTests;

[TestClass]
public class ProfessionalQueriesTest
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
    public ProfessionalQueriesTest()
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
    public void Professional_Query_Get_All()
    {
        List<Professional> professionals = _professionals.AsQueryable().Where(Queries.ProfessonalQueries.GetAll()).ToList();
        var result = professionals;
        Assert.AreEqual(result.Count, 3);
    }
    [TestMethod]
    public void Professional_Query_Get_By_Id()
    {
        var selectProfessional = _professionals[0];
        var result = _professionals.AsQueryable().Where(Queries.ProfessonalQueries.GetById(selectProfessional.Id)).FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual(selectProfessional.Id, result.Id);
        Assert.AreEqual(selectProfessional, result);
    }
    [TestMethod]
    public void Professional_Query_Get_All_Professonal_By_Service_Id()
    {
        var firstProfessional = _professionals[0];
        var secondProfessional = _professionals[0];
        foreach (var service in _services)
        {
            firstProfessional.AddService(service.Id);
            secondProfessional.AddService(service.Id);
        }
        var serviceSelected = _services[0];
        var result = _professionals.AsQueryable().Where(Queries.ProfessonalQueries.GetAllProfessonalByServiceId(serviceSelected.Id)).ToList();
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count > 0, "Nenhum profissional associado ao serviço foi encontrado.");
        foreach (var item in result)
        {
            Assert.IsTrue(item.Services.Any(x => x.ServiceId == serviceSelected.Id));
        }
    }

}