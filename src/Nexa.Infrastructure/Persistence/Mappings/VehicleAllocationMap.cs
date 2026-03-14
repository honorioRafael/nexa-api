using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class VehicleAllocationMap : IEntityTypeConfiguration<VehicleAllocation>
{
    public void Configure(EntityTypeBuilder<VehicleAllocation> builder)
    {
        builder.ToTable("vehicle_allocation");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartDate).IsRequired();

        builder.HasOne(x => x.Driver)
            .WithMany()
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
