

using Barber.Domain.Entity;

namespace Barber.Domain.Repository;
public interface iProfessionalServiceRepository
{
    Task CreateAync(ProfessionalServiceJoint professionalServiceJoint);
    Task DeleteAsync(Guid id);
    Task GetAllAsync();
    Task GetByIdAsync(Guid id);
    Task<ICollection<ProfessionalServiceJoint>> GetAllByProfessionalId(Guid professionalId);
    Task<ICollection<ProfessionalServiceJoint>> GetAllByServiceId(Guid serviceId);
    
}
