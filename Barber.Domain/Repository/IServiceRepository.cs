using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface IServiceRepository
{
    Task CreateAsync(Services service);
    Task UpdateAsync(Services service);
    Task DeleteAsync(Services service);
    Task<Services> GetByIdAsync(Guid id);
    Task<ICollection<Services>> GetAllAsync();
    Task<ICollection<Services>> GetAllServicesByProfessonalIdAsync(Guid professonal);
    
}