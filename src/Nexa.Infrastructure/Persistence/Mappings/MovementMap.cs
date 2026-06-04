using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class MovementMap : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.ToTable("movement");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type).IsRequired().HasConversion<int>();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.StatusLabel).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Housing)
            .WithMany()
            .HasForeignKey(x => x.HousingId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
