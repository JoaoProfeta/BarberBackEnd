using System.Linq.Expressions;
using Barber.Domain.Entity;

namespace Barber.Domain.Queries;
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
        return x => x.ProfessionalsServices.FirstOrDefault().ProfessionalId == professonalId;
    }
    public static Expression<Func<Scheduling, bool>> GetAllSchedulingByServicecId(Guid serviceId)
    {
        return x => x.ProfessionalsServices.FirstOrDefault().ServiceId == serviceId;
    }
}
