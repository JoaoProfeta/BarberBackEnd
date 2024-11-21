using Barber.Domain.Entity;
using Barber.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.FakeRepository;

public class FakeProfessionalRepository : IProfessionalRepository
{
    private readonly List<Professional> _professionals = new();

    public Task CreateAsync(Professional professionals)
    {
        _professionals.Add(professionals);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Professional professionals)
    {
        _professionals.Remove(professionals);
        return Task.CompletedTask;
    }

    public Task<ICollection<Professional>> GetAllAsync()
    {
        return Task.FromResult((ICollection<Professional>)_professionals);

    }

    public Task<ICollection<Professional>> GetAllProfessonalByServiceIdAsync(ICollection<Guid> Id)
    {
        var result = _professionals.Where(p => p.Services.Any(s => Id.Contains(s.Id))).ToList();

        return Task.FromResult((ICollection<Professional>)result);

    }

    public Task<Professional> GetByIdAsync(Guid id)
    {
        var professional = _professionals.FirstOrDefault(p => p.ProfessionalId == id);
        return Task.FromResult(professional);
    }

    public Task UpdateAsync(Professional professionals)
    {
        var existingProfessional = _professionals.FirstOrDefault(p => p.ProfessionalId == professionals.ProfessionalId);
        if (existingProfessional != null)
        {
            _professionals.Remove(existingProfessional);
            _professionals.Add(professionals);
        }
        return Task.CompletedTask;
    }
}

