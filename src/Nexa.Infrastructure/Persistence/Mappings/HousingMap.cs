using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class HousingMap : IEntityTypeConfiguration<Housing>
{
    public void Configure(EntityTypeBuilder<Housing> builder)
    {
        builder.ToTable("housing");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

        builder.Property(x => x.AddressId).IsRequired();
        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(20);
        builder.Property(x => x.MaxCapacity).IsRequired();
        builder.Property(x => x.CurrentCapacity).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasConversion<string>();
        builder.Property(x => x.UseHousingRoom).IsRequired();
    }
}
