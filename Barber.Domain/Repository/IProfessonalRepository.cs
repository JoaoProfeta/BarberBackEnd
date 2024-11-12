using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface IProfessonalRepository
{
    Task CreateAsync(Professonals professonals);
    Task UpdateAsync(Professonals professonals);
    Task DeleteAsync(Professonals professonals);
    Task<Professonals> GetByIdAsync(Guid id);
    Task<ICollection<Professonals>> GetAllAsync();
    Task<ICollection<Professonals>> GetAllProfessonalByServiceIdAsync(ICollection<Guid> Id);
}