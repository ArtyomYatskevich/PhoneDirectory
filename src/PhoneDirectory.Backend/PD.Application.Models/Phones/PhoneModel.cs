namespace PhoneDirectory.Backend.Application.Models.Phones;

public class PhoneModel
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Number { get; set; }
}