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
        private readonly List<Service> _service = new();
        public Task CreateAsync(Service service)
        {
            _service.Add(service);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Service service)
        {
            _service.Remove(service);
            return Task.CompletedTask;
        }

        public Task<ICollection<Service>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Service>)_service);
        }

        public Task<ICollection<Service>> GetAllServicesByProfessonalIdAsync(Guid professonal)
        {
            var result = _service.Where(s => s.Professionals.Any(p => p.Id == professonal));
            return Task.FromResult((ICollection<Service>)result);
        }

        public Task<Service> GetByIdAsync(Guid id)
        {
            var service = _service.FirstOrDefault(s => s.Id == id); 
            return Task.FromResult(service);
        }

        public Task UpdateAsync(Service service)
        {
            var existingProfessional = _service.FirstOrDefault(p => p.Id == service.Id);
            if (existingProfessional != null)
            {
                _service.Remove(existingProfessional);
                _service.Add(service);
            }
            return Task.CompletedTask;
        }
    }
}
