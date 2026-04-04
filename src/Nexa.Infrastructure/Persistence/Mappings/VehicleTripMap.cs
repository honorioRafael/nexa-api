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

        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.Distance).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasConversion<int>();

        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.CurrentOcupation).IsRequired();

        builder.HasOne(x => x.Driver)
            .WithMany()
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OriginAddress)
            .WithMany()
            .HasForeignKey(x => x.OriginAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DestinationAddress)
            .WithMany()
            .HasForeignKey(x => x.DestinationAddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
