using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class HousingAllocationMap : IEntityTypeConfiguration<HousingAllocation>
{
    public void Configure(EntityTypeBuilder<HousingAllocation> builder)
    {
        builder.ToTable("housing_allocation");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CheckInDate).IsRequired();

        builder.HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Housing)
            .WithMany()
            .HasForeignKey(x => x.HousingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
