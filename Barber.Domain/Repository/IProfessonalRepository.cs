using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface IProfessonalRepository
{
    Task CreateAsync(Professional professonals);
    Task UpdateAsync(Professional professonals);
    Task DeleteAsync(Professional professonals);
    Task<Professional> GetByIdAsync(Guid id);
    Task<ICollection<Professional>> GetAllAsync();
    Task<ICollection<Professional>> GetAllProfessonalByServiceIdAsync(ICollection<Guid> Id);
}