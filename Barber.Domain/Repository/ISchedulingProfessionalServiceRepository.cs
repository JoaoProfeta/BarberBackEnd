

using Barber.Domain.Entity;

namespace Barber.Domain.Repository;
public interface ISchedulingProfessionalServiceRepository
{
    Task CreateAync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint);
    Task DeleteAsync(Guid id);
    Task GetAllAsync();
    Task GetByIdAsync(Guid id);
    Task<ICollection<SchedulingProfessionalServiceJoint>> GetBySchedulingId(Guid schedulingId);
    Task<ICollection<ProfessionalServiceJoint>> GetAllByProfessionalId(Guid professionalId);
    Task<ICollection<ProfessionalServiceJoint>> GetAllByServiceId(Guid serviceId);
}
