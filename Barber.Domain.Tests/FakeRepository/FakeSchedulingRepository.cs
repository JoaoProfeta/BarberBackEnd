using Barber.Domain.Entity;
using Barber.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.FakeRepository;

internal class FakeSchedulingRepository : ISchedulingRepository
{
    private readonly List<Scheduling> _scheduling = new();
    public Task CreateAsync(Scheduling scheduling)
    {
        _scheduling.Add(scheduling);
        return Task.CompletedTask;
    }
    public Task DeleteAsync(Scheduling scheduling)
    {
        _scheduling.Remove(scheduling);
        return Task.CompletedTask;
    }
    public Task<ICollection<Scheduling>> GetAllAsync()
    {
        return Task.FromResult((ICollection<Scheduling>)_scheduling);
    }
    public Task<ICollection<Scheduling>> GetAllSchedulingByProfessonalId(Guid professonalId)
    {
        var result = _scheduling.Where(x => x.SchedulingProfessionalsServices.Any(p => p.ProfessionalServiceJoint.ProfessionalId == professonalId)).ToList();
        return Task.FromResult((ICollection<Scheduling>)result);
    }
    public Task<ICollection<Scheduling>> GetAllSchedulingByServiceIdAsync(Guid serviceId)
    {
        var result = _scheduling.Where(x => x.SchedulingProfessionalsServices.Any(s => s.ProfessionalServiceJoint.ServiceId == serviceId)).ToList();
        return Task.FromResult((ICollection<Scheduling>)result);
    }
    public Task<Scheduling> GetByIdAsync(Guid id)
    {
        var result = _scheduling.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(result);
    }
    public Task UpdateAsync(Scheduling scheduling)
    {
        var existingProfessional = _scheduling.FirstOrDefault(p => p.Id == scheduling.Id);
        if (existingProfessional != null)
        {
            _scheduling.Remove(existingProfessional);
            _scheduling.Add(scheduling);
        }
        return Task.CompletedTask;
    }
}

