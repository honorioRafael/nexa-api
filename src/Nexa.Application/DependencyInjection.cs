using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Nexa.Application.Interfaces.Services;
using Nexa.Application.Services;
using Nexa.Application.Validators.User;

namespace Nexa.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Validators
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

        // Services
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IHomePageService, HomePageService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IHousingService, HousingService>();
        services.AddScoped<IVehicleModelService, VehicleModelService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IHousingAllocationService, HousingAllocationService>();
        services.AddScoped<IVehicleTripService, VehicleTripService>();
        services.AddScoped<IVehicleMaintenanceService, VehicleMaintenanceService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IHousingRoomService, HousingRoomService>();
        services.AddScoped<IVehicleTripEmployeeService, VehicleTripEmployeeService>();
        services.AddScoped<IVehicleTripStopService, VehicleTripStopService>();

        return services;
    }
}
