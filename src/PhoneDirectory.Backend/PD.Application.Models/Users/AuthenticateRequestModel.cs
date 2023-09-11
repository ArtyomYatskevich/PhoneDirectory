namespace PhoneDirectory.Backend.Application.Models.Users;

public class AuthenticateRequestModel
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}