using Barber.Domain.Enum;

namespace Barber.Domain.Entity;

public class User : Entity
{
    public User(
        string name,
        string email,
        string phone,
        EUserType userType
    )
    {
        Name = name;
        Email = email;
        Phone = phone;
        UserType = userType;
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public EUserType UserType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsActive { get; private set; }

    public void UpdateName(string name) => Name = name;
    public void UpdateEmail(string email) => Email = email;
    public void UpdatePhone(string phone) => Phone = phone;
    public void UpdateUserType(EUserType userType) => UserType = userType;
    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}