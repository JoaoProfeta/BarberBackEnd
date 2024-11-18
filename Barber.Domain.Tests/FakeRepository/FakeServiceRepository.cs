using Barber.Domain.Entity;
using Barber.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Domain.Tests.FakeRepository
{
    internal class FakeServiceRepository : IServiceRepository
    {
        public Task CreateAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Service>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Service>> GetAllServicesByProfessonalIdAsync(Guid professonal)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Service service)
        {
            throw new NotImplementedException();
        }
    }
}
