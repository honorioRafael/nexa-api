using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class VehicleModelMap : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("vehicle_model");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Manufacturer).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.MaxCapacity).IsRequired();
        builder.Property(x => x.Type).IsRequired().HasConversion<string>();
        builder.Property(x => x.FuelType).IsRequired().HasConversion<string>();
    }
}
