using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Repositories;

namespace Nexa.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        // Repositories
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IHousingRepository, HousingRepository>();
        services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
        services.AddTransient<IVehicleRepository, VehicleRepository>();
        services.AddTransient<IDriverRepository, DriverRepository>();
        services.AddTransient<IHousingAllocationRepository, HousingAllocationRepository>();
        services.AddTransient<IVehicleAllocationRepository, VehicleAllocationRepository>();
        services.AddTransient<IVehicleTripRepository, VehicleTripRepository>();
        services.AddTransient<IVehicleMaintenanceRepository, VehicleMaintenanceRepository>();

        // Services
        services.AddTransient<IAuthenticateService, AuthenticateService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        services.AddTransient<IHousingService, HousingService>();
        services.AddTransient<IVehicleModelService, VehicleModelService>();
        services.AddTransient<IVehicleService, VehicleService>();
        services.AddTransient<IDriverService, DriverService>();
        services.AddTransient<IHousingAllocationService, HousingAllocationService>();
        services.AddTransient<IVehicleAllocationService, VehicleAllocationService>();
        services.AddTransient<IVehicleTripService, VehicleTripService>();
        services.AddTransient<IVehicleMaintenanceService, VehicleMaintenanceService>();

        return services;
    }
}
