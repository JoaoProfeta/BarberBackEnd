using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Entity;
using Barber.Domain.Repository;

namespace Barber.Domain.Tests.FakeRepository;
public class FakeProfessionalServiceRepository : IProfessionalServiceRepository
{
    private readonly List<ProfessionalServiceJoint> _fakeList = new();
    public Task CreateAync(ProfessionalServiceJoint professionalServiceJoint)
    {
        _fakeList.Add(professionalServiceJoint);
        return Task.CompletedTask;
    }
    public Task DeleteAsync(ProfessionalServiceJoint professionalServiceJoint)
    {
        _fakeList.Remove(professionalServiceJoint);
        return Task.CompletedTask;
    }
    public Task<ICollection<ProfessionalServiceJoint>> GetAllAsync()
    {
        return Task.FromResult((ICollection<ProfessionalServiceJoint>)_fakeList);
    }
    public Task<ICollection<ProfessionalServiceJoint>> GetAllByProfessionalId(Guid professionalId)
    {
        var result = _fakeList.Where(p => p.ProfessionalId == professionalId);
        return Task.FromResult((ICollection<ProfessionalServiceJoint>)result);
    }
    public Task<ICollection<ProfessionalServiceJoint>> GetAllByServiceId(Guid serviceId)
    {
        var result = _fakeList.Where(p => p.ServiceId == serviceId);
        return Task.FromResult((ICollection<ProfessionalServiceJoint>)result);
    }
    public Task<ProfessionalServiceJoint> GetByIdAsync(Guid id)
    {
        var result = _fakeList.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(result);
    }
}
