using System.Linq.Expressions;
using Barber.Domain.Entity;

namespace Barber.Domain.Queries;
public static class ProfessonalQueries
{
    public static Expression<Func<Professional, bool>> GetById(Guid id)
    {
        return x => x.Id == id;
    }
    public static Expression<Func<Professional, bool>> GetAll()
    {
        return x => true;
    }
    public static Expression<Func<Professional, bool>> GetAllProfessonalByServiceId(Guid serviceId)
    {
        return x => x.Services.Any(s => s.Id == serviceId);
    }
    public static Expression<Func<Professional, bool>> GetAllProfessonalBySchedulingId(Guid scheduleId)
    {
        return x => x.Schedulings.Any(s => s.Id == scheduleId);
    }
}
