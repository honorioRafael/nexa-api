using FluentValidation;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services;
using Nexa.Application.Validators.User;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Repositories;

namespace Nexa.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

        // Repositories
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IHousingRepository, HousingRepository>();
        services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
        services.AddTransient<IVehicleRepository, VehicleRepository>();
        services.AddTransient<IDriverRepository, DriverRepository>();
        services.AddTransient<IHousingAllocationRepository, HousingAllocationRepository>();
        services.AddTransient<IVehicleTripRepository, VehicleTripRepository>();
        services.AddTransient<IVehicleMaintenanceRepository, VehicleMaintenanceRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IHousingRoomRepository, HousingRoomRepository>();
        services.AddTransient<IVehicleTripEmployeeRepository, VehicleTripEmployeeRepository>();
        services.AddTransient<IVehicleTripStopRepository, VehicleTripStopRepository>();

        // Services
        services.AddTransient<IAuthenticateService, AuthenticateService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        services.AddTransient<IHousingService, HousingService>();
        services.AddTransient<IVehicleModelService, VehicleModelService>();
        services.AddTransient<IVehicleService, VehicleService>();
        services.AddTransient<IDriverService, DriverService>();
        services.AddTransient<IHousingAllocationService, HousingAllocationService>();
        services.AddTransient<IVehicleTripService, VehicleTripService>();
        services.AddTransient<IVehicleMaintenanceService, VehicleMaintenanceService>();
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IHousingRoomService, HousingRoomService>();
        services.AddTransient<IVehicleTripEmployeeService, VehicleTripEmployeeService>();
        services.AddTransient<IVehicleTripStopService, VehicleTripStopService>();

        return services;
    }
}
