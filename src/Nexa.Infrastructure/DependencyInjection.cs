using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nexa.Application.Interfaces.Services;
using Nexa.Domain.Interfaces.Repositories;
using Nexa.Infrastructure.Authentication;
using Nexa.Infrastructure.Persistence;
using Nexa.Infrastructure.Repositories;
using System.Text;

namespace Nexa.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Entity Framework Core + PostgreSQL
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // JWT Settings
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName);
        services.Configure<JwtSettings>(jwtSettings);

        // Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
                ClockSkew = TimeSpan.Zero
            };
        });

        // Infrastructure Services
        services.AddScoped<ITokenService, TokenService>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IHousingRepository, HousingRepository>();
        services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IHousingAllocationRepository, HousingAllocationRepository>();
        services.AddScoped<IVehicleTripRepository, VehicleTripRepository>();
        services.AddScoped<IVehicleMaintenanceRepository, VehicleMaintenanceRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IHousingRoomRepository, HousingRoomRepository>();
        services.AddScoped<IVehicleTripEmployeeRepository, VehicleTripEmployeeRepository>();
        services.AddScoped<IVehicleTripStopRepository, VehicleTripStopRepository>();

        return services;
    }
}
