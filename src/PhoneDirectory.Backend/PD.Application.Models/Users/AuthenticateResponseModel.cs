using System.Text.Json.Serialization;

namespace PhoneDirectory.Backend.Application.Models.Users;

public class AuthenticateResponseModel
{
    public int UserId { get; set; }
    
    public required string Email { get; set; }

    public required string Token { get; set; }
    
    [JsonIgnore]
    public string RefreshToken { get; set; } = null!;
}