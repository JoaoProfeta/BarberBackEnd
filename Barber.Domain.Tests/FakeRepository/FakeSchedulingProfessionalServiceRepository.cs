using Barber.Domain.Entity;
using Barber.Domain.Repository;

namespace Barber.Domain.Tests.FakeRepository;

public class FakeSchedulingProfessionalServiceRepository : ISchedulingProfessionalServiceRepository
{
    private readonly List<SchedulingProfessionalServiceJoint> _fakeList = new();
    public Task CreateAync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint)
    {
        _fakeList.Add(schedulingProfessionalServiceJoint);
        return Task.CompletedTask;
    }
    public Task DeleteAsync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint)
    {
        _fakeList.Remove(schedulingProfessionalServiceJoint);
        return Task.CompletedTask;
    }
    public Task<ICollection<SchedulingProfessionalServiceJoint>> GetAllAsync()
    {
        return Task.FromResult((ICollection<SchedulingProfessionalServiceJoint>)_fakeList);
    }
    public Task<ICollection<SchedulingProfessionalServiceJoint>> GetAllByProfessionalId(Guid professionalId)
    {
        var result = _fakeList.Where(x => x.ProfessionalServiceJoint.ProfessionalId == professionalId);
        return Task.FromResult((ICollection<SchedulingProfessionalServiceJoint>)result);
    }
    public Task<ICollection<SchedulingProfessionalServiceJoint>> GetAllByServiceId(Guid serviceId)
    {
        var result = _fakeList.Where(x => x.ProfessionalServiceJoint.ServiceId == serviceId);
        return Task.FromResult((ICollection<SchedulingProfessionalServiceJoint>)result);
    }
    public Task<SchedulingProfessionalServiceJoint> GetByIdAsync(Guid id)
    {
        var result = _fakeList.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(result);
    }
    public Task<ICollection<SchedulingProfessionalServiceJoint>> GetBySchedulingId(Guid schedulingId)
    {
        var result = _fakeList.Where(x => x.SchedulingId == schedulingId).ToList();
        return Task.FromResult((ICollection<SchedulingProfessionalServiceJoint>)result);
    }
    public Task UpdateAsync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint)
    {
        var result = _fakeList.FirstOrDefault(x => x.Id == schedulingProfessionalServiceJoint.Id);
        if (result != null)
        {
            _fakeList.Remove(result);
            _fakeList.Add(schedulingProfessionalServiceJoint);
        }
        return Task.CompletedTask;
    }
}