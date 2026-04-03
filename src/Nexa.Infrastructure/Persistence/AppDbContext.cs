using Microsoft.EntityFrameworkCore;

using Nexa.Domain.Entities;

namespace Nexa.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Driver> Driver => Set<Driver>();
    public DbSet<Employee> Employee => Set<Employee>();
    public DbSet<Housing> Housing => Set<Housing>();
    public DbSet<HousingAllocation> HousingAllocation => Set<HousingAllocation>();
    public DbSet<HousingRoom> HousingRoom => Set<HousingRoom>();
    public DbSet<User> User => Set<User>();
    public DbSet<Vehicle> Vehicle => Set<Vehicle>();
    public DbSet<VehicleMaintenance> VehicleMaintenance => Set<VehicleMaintenance>();
    public DbSet<VehicleModel> VehicleModel => Set<VehicleModel>();
    public DbSet<VehicleTrip> VehicleTrip => Set<VehicleTrip>();
    public DbSet<VehicleTripEmployee> VehicleTripEmployee => Set<VehicleTripEmployee>();
    public DbSet<VehicleTripStop> VehicleTripStop => Set<VehicleTripStop>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
