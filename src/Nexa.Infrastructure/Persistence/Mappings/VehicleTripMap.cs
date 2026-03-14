using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class VehicleTripMap : IEntityTypeConfiguration<VehicleTrip>
{
    public void Configure(EntityTypeBuilder<VehicleTrip> builder)
    {
        builder.ToTable("vehicle_trip");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Origin).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Destination).IsRequired().HasMaxLength(255);
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.Distance).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.HasOne(x => x.VehicleAllocation)
            .WithMany()
            .HasForeignKey(x => x.VehicleAllocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
