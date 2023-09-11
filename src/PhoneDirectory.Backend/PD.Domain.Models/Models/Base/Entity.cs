namespace PhoneDirectory.Backend.Models.Models.Base;

public abstract class Entity
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
}