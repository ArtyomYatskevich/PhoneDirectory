using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Data.Configurations;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("Phone");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Number).HasColumnName("Number").HasMaxLength(15).IsRequired();
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}