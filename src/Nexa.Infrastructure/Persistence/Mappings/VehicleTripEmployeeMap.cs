using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class VehicleTripEmployeeMap : IEntityTypeConfiguration<VehicleTripEmployee>
{
    public void Configure(EntityTypeBuilder<VehicleTripEmployee> builder)
    {
        builder.ToTable("vehicle_trip_employee");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.VehicleTrip)
            .WithMany()
            .HasForeignKey(x => x.VehicleTripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
