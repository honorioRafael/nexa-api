using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class HousingRoomMap : IEntityTypeConfiguration<HousingRoom>
{
    public void Configure(EntityTypeBuilder<HousingRoom> builder)
    {
        builder.ToTable("housing_room");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Capacity).IsRequired();
        builder.Property(x => x.HousingRoomType).IsRequired().HasConversion<int>();

        builder.HasOne(x => x.Housing)
            .WithMany()
            .HasForeignKey(x => x.HousingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
