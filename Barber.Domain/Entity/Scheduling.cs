using Barber.Domain.Enum;

namespace Barber.Domain.Entity;
public class Scheduling : Entity
{
    public Scheduling(
        Guid customerId,
        DateTime schedulingTime,
        string? observations = null
    )
    {
        CustomerId = customerId;
        SchedulingTime = schedulingTime;
        Observations = observations;
        SchedulingStatus = ESchedulingStatus.Pending;
        SchedulingProfessionalsServices = new List<SchedulingProfessionalServiceJoint>();
        CreatedAt = DateTime.UtcNow;
        TotalPrice = 0;
    }

    public Guid CustomerId { get; private set; }
    public DateTime SchedulingTime { get; private set; }
    public string? Observations { get; private set; }
    public ESchedulingStatus SchedulingStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public decimal TotalPrice { get; private set; }
    
    // Navigation Properties
    public Customer Customer { get; private set; }
    public ICollection<SchedulingProfessionalServiceJoint> SchedulingProfessionalsServices { get; private set; }

    public void UpdateDate(DateTime date) => SchedulingTime = date;
    public void UpdateObservations(string? observations) => Observations = observations;
    public void UpdateSchedulingStatus(ESchedulingStatus status) => SchedulingStatus = status;
    public void UpdateTotalPrice(decimal totalPrice) => TotalPrice = totalPrice;

    public void AddProfessionalService(Guid professionalServiceJointId)
    {
        if (!SchedulingProfessionalsServices.Any(s => s.ProfessionalServiceJointId == professionalServiceJointId))
        {
            var create = new SchedulingProfessionalServiceJoint(this.Id, professionalServiceJointId);
            SchedulingProfessionalsServices.Add(create);
        }
    }

    public void RemoveProfessionalService(Guid professionalServiceJointId)
    {
        var item = SchedulingProfessionalsServices.FirstOrDefault(s => s.ProfessionalServiceJointId == professionalServiceJointId);
        if (item != null)
        {
            SchedulingProfessionalsServices.Remove(item);
        }
    }

    public void CalculateTotalPrice()
    {
        // Este método deveria calcular o preço total baseado nos serviços agendados
        // Seria implementado com base nos preços dos serviços relacionados
        decimal total = 0;
        // Lógica de cálculo seria implementada aqui
        TotalPrice = total;
    }

    public DateTime GetEstimatedEndTime()
    {
        // Este método calcularia o tempo estimado de término baseado na duração dos serviços
        // Seria implementado com base na duração dos serviços relacionados
        return SchedulingTime; // Placeholder - implementação real dependeria dos serviços
    }

    public bool CanBeCancelled()
    {
        return SchedulingStatus == ESchedulingStatus.Pending && 
               SchedulingTime > DateTime.UtcNow.AddHours(2); // Exemplo: pode cancelar até 2h antes
    }
}
