namespace PhoneDirectory.Backend.Infrastructure.Configs;

public class AuthConfig
{
    public const string Key = "App:Auth";
    
    public required string Issuer { get; set; }

    public required string Audience { get; set; }
    
    public required string SecretKey { get; set; }
    
    public required int AuthTokenLifeDays { get; set; }

    public required int AuthRefreshTokenLifeDays { get; set; }

    public required int CookieLifeDays { get; set; }

    public required int CookieLifeExtendedDays { get; set; }
}