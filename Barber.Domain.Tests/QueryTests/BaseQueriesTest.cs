using Barber.Domain.Entity;
using Barber.Domain.Tests.FakeRepository;

namespace Barber.Domain.Tests.QueryTests;

public class BaseQueriesTest
{
    public List<Professional> Professionals = new();
    public List<Service> Services = new();
    public List<Scheduling> Schedulings = new();
    public List<Guid> ProfessionalsId = new()
    {
        Guid.Parse("d13f54b8-8f3f-4148-8bd2-5f2f098c90c6"),
        Guid.Parse("b27f0c74-f9d4-453b-a8d5-7b6e0c4b1e6c"),
        Guid.Parse("6ea3b8c7-29b9-4c18-9a1b-b7803c8b58ab"),
        Guid.Parse("849be646-418b-47c5-ab7d-e20d4e3c3509"),
        Guid.Parse("06441137-a024-4992-91d9-1b3090206d31"),
        Guid.Parse("a726b00c-ccb1-43eb-9a9d-dfc2485d37b7"),
        Guid.Parse("1842d9f0-7a5a-47d7-8e4c-7b1ecc84db8f")
    };
    public List<Guid> ServicesId = new()
    {
        Guid.Parse("22439d89-2677-4377-aeb7-e5f954aad3c7"),
        Guid.Parse("f53a67c6-3d43-4f25-978a-6fe9038a27e0"),
        Guid.Parse("9888e552-e2b6-4f51-af1e-dc23d338f593"),
        Guid.Parse("b473af2f-e205-43b0-ad3d-9676565f239e"),
        Guid.Parse("954a6a87-33de-43e8-a895-e0a5432e728b"),
        Guid.Parse("0987272a-40c0-41e9-8af0-1e9c5ba85bbf"),
    };
    public List<Guid> SchedulingsId = new()
    {
        Guid.Parse("14346554-9ba1-4c45-a3dd-8c84d7d8d60f"),
        Guid.Parse("165120ff-cdc7-40cd-b229-5a390aa09762"),
        Guid.Parse("9145930d-d299-43dc-bb69-e0145eecfe1e"),
        Guid.Parse("56d83f8d-6858-4689-9703-eeb5a8e89874"),
        Guid.Parse("260d4a7a-1d50-4140-a27a-164f8267702f"),
        Guid.Parse("219fc958-d7c6-42c4-a095-4a6f8d8a522d"),
    };
    public BaseQueriesTest()
    {
        
    }


}