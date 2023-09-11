namespace PhoneDirectory.Backend.Infrastructure.Configs;

public class DatabaseConfig
{
    public const string Key = "App:Database";
    
    public required string ConnectionString { get; set; }
}