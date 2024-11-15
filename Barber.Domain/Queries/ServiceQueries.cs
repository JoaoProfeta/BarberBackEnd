using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Entity;

namespace Barber.Domain.Queries
{
    public static class ServiceQueries
    {
        public static Expression<Func<Service, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Service, bool>> GetAll()
        {
            return x => true;
        }
        public static Expression<Func<Service, bool>> GetAllServicesByProfessonalId(Guid professonalId)
        {
            return x => x.Professionals.Any(p => p.Id == professonalId);
        }
       

    }
}
