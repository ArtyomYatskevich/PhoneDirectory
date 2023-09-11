using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(30).IsRequired();
        
        builder
            .HasMany(x => x.Phones)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}