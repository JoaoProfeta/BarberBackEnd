using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface IProfessionalRepository
{
    Task CreateAsync(Professional professionals);
    Task UpdateAsync(Professional professionals);
    Task DeleteAsync(Professional professionals);
    Task<Professional> GetByIdAsync(Guid id);
    Task<ICollection<Professional>> GetAllAsync();
    Task<ICollection<Professional>> GetAllProfessonalByServiceIdAsync(ICollection<Guid> Id);
}