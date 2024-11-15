using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface ISchedulingRepository
{
    Task CreateAsync(Scheduling scheduling);
    Task UpdateAsync(Scheduling scheduling);
    Task DeleteAsync(Scheduling scheduling);
    Task<Scheduling> GetByIdAsync(Guid id);
    Task<ICollection<Scheduling>> GetAllAsync();
    Task<ICollection<Scheduling>> GetAllSchedulingByProfessonalId(Guid professonalId);
    Task<ICollection<Service>> GetAllSchedulingByServiceIdAsync(Guid schedulingId);

}