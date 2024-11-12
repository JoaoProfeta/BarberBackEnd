using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Barber.Domain.Entity;

namespace Barber.Domain.Queries
{
    public static class SchedulingQueries
    {
        public static Expression<Func<Scheduling, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Scheduling, bool>> GetAll()
        {
            return x => true;
        }
        public static Expression<Func<Scheduling, bool>> GetAllSchedulingByProfessonalId(Guid professonalId)
        {
            return x => x.ProfessionalSelectedId == professonalId;
        }
        public static Expression<Func<Scheduling, bool>> GetAllSchedulingByServicecId(Guid serviceId)
        {
            return x => x.ServicesSelected.Any(s => s.Id == serviceId);
        }
    }
}
