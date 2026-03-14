using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicle");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.LicensePlate).IsRequired().HasMaxLength(20);
        builder.Property(x => x.ChassisNumber).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Mileage).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.HasOne(x => x.VehicleModel)
            .WithMany()
            .HasForeignKey(x => x.VehicleModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
