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
    }
    //[TestMethod]
    public void Professional_Query_Get_All()
    {
        List<Professional> professionals = _professionals.AsQueryable().Where(Queries.ProfessonalQueries.GetAll()).ToList();
        var result = professionals;
        Assert.AreEqual(result.Count, 3);
    }
    //[TestMethod]
    public void Professional_Query_Get_By_Id()
    {
        var selectProfessional = _professionals[0];
        var result = _professionals.AsQueryable().Where(Queries.ProfessonalQueries.GetById(selectProfessional.Id)).FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual(selectProfessional.Id, result.Id);
        Assert.AreEqual(selectProfessional, result);
    }
    //[TestMethod]
    public void Professional_Query_Get_All_Professonal_By_Service_Id()
    {
        var selectedService = _services[2];
        var result = _professionals.AsQueryable().Where(Queries.ProfessonalQueries.GetAllProfessonalByServiceId(selectedService.Id)).ToList();

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count > 0, "Nenhum profissional associado ao serviço foi encontrado.");

        foreach (var item in result)
        {
            //Assert.IsTrue(item.Services.Contains());
        }

    }
    //[TestMethod]
    public void Get_All_Professonal_By_Scheduling_Id()
    {

    }
}