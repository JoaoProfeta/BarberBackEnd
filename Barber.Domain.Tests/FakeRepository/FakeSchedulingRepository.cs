using Barber.Domain.Entity;
using Barber.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.FakeRepository
{
    internal class FakeSchedulingRepository : ISchedulingRepository
    {
        public Task CreateAsync(Scheduling scheduling)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Scheduling scheduling)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Scheduling>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Scheduling>> GetAllSchedulingByProfessonalId(Guid professonalId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Service>> GetAllSchedulingByServiceIdAsync(Guid schedulingId)
        {
            throw new NotImplementedException();
        }

        public Task<Scheduling> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Scheduling scheduling)
        {
            throw new NotImplementedException();
        }
    }
}
