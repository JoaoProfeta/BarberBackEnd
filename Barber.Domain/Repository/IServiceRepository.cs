using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface IServiceRepository
{
    Task CreateAsync(Service service);
    Task UpdateAsync(Service service);
    Task DeleteAsync(Service service);
    Task<Service> GetByIdAsync(Guid id);
    Task<ICollection<Service>> GetAllAsync();
    Task<ICollection<Service>> GetAllServicesByProfessonalIdAsync(Guid professional);
}