namespace Barber.Domain.Entity;

public class User : Entity
{
    public User(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; private set; }
}