namespace Barber.Domain.Entity;

public class Customer : Entity
{
    public Customer(
        string name,
        string email,
        string phone
    )
    {
        Name = name;
        Email = email;
        Phone = phone;
        Schedulings = new List<Scheduling>();
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }
    public ICollection<Scheduling> Schedulings { get; private set; }

    public void UpdateName(string name) => Name = name;
    public void UpdateEmail(string email) => Email = email;
    public void UpdatePhone(string phone) => Phone = phone;
    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}