using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Street).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Number).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Complement).HasMaxLength(255);
        builder.Property(x => x.Neighborhood).IsRequired().HasMaxLength(150);
        builder.Property(x => x.City).IsRequired().HasMaxLength(150);
        builder.Property(x => x.State).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(100);
        builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(20);
    }
}
