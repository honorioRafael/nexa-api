using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class VehicleTripStopMap : IEntityTypeConfiguration<VehicleTripStop>
{
    public void Configure(EntityTypeBuilder<VehicleTripStop> builder)
    {
        builder.ToTable("vehicle_trip_stop");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.QueuePosition).IsRequired();

        builder.HasOne(x => x.VehicleTrip)
            .WithMany(x => x.ListVehicleTripStop)
            .HasForeignKey(x => x.VehicleTripId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
