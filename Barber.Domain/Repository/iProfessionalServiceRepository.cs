
using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface IProfessionalServiceRepository
{
    Task CreateAync(ProfessionalServiceJoint professionalServiceJoint);
    Task DeleteAsync(ProfessionalServiceJoint professionalServiceJoint);
    Task GetAllAsync();
    Task<ProfessionalServiceJoint> GetByIdAsync(Guid id);
    Task<ICollection<ProfessionalServiceJoint>> GetAllByProfessionalId(Guid professionalId);
    Task<ICollection<ProfessionalServiceJoint>> GetAllByServiceId(Guid serviceId);

