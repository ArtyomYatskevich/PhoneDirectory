namespace PhoneDirectory.Backend.Application.Models.Phones;

public class UpdatePhoneModel
{
    public required string Name { get; set; }
    
    public required string Number { get; set; }
}