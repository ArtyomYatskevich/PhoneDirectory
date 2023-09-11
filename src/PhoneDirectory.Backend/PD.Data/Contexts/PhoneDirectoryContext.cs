using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PhoneDirectory.Backend.Infrastructure.Configs;
using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Data.Contexts;

public class PhoneDirectoryContext : DbContext
{
    private readonly DatabaseConfig _databaseConfig;
    
    public PhoneDirectoryContext(IOptions<DatabaseConfig> databaseConfigOptions)
    {
        _databaseConfig = databaseConfigOptions.Value;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@gmail.com",
                Password = "admin"
            }
        );
        
        modelBuilder.Entity<Phone>().HasData(
            new Phone
            {
                Id = 1,
                Name = "Test 1",
                Number = "123-456",
                UserId = 1
            },
            new Phone
            {
                Id = 2,
                Name = "Test 2",
                Number = "222-456",
                UserId = 1
            }
        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_databaseConfig.ConnectionString, ServerVersion.AutoDetect(_databaseConfig.ConnectionString));

    public virtual DbSet<User> Users { get; set; } = null!;
    
    public virtual DbSet<Phone> Phones { get; set; } = null!;
}