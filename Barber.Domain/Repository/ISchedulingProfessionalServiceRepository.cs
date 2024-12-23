﻿using Barber.Domain.Entity;

namespace Barber.Domain.Repository;

public interface ISchedulingProfessionalServiceRepository
{
    Task CreateAync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint);
    Task DeleteAsync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint);
    Task UpdateAsync(SchedulingProfessionalServiceJoint schedulingProfessionalServiceJoint);
    Task<SchedulingProfessionalServiceJoint> GetByIdAsync(Guid id);
    Task<ICollection<SchedulingProfessionalServiceJoint>> GetAllAsync();
    Task<ICollection<SchedulingProfessionalServiceJoint>> GetBySchedulingId(Guid schedulingId);
    Task<ICollection<SchedulingProfessionalServiceJoint>> GetAllByProfessionalId(Guid professionalId);
    Task<ICollection<SchedulingProfessionalServiceJoint>> GetAllByServiceId(Guid serviceId);
}
