using Microsoft.EntityFrameworkCore;
using Nexa.Domain.Entities;
using Nexa.Domain.Enums;
using Nexa.Infrastructure.Persistence;

namespace Nexa.API;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        Console.WriteLine($"[Seeder] Current Employees: {await context.Employee.CountAsync()}");
        Console.WriteLine($"[Seeder] Current Housings: {await context.Housing.CountAsync()}");
        Console.WriteLine($"[Seeder] Current Vehicles: {await context.Vehicle.CountAsync()}");
        Console.WriteLine($"[Seeder] Current Movements: {await context.Movement.CountAsync()}");

        var existingMovements = await context.Movement.ToListAsync();
        if (existingMovements.Any())
        {
            context.Movement.RemoveRange(existingMovements);
            await context.SaveChangesAsync();
            Console.WriteLine("[Seeder] Cleared existing Movements.");
        }

        var employees = await context.Employee.ToListAsync();
        if (!employees.Any())
        {
            employees = new List<Employee>
            {
                new() { Name = "Carlos Santos", Cpf = "111.111.111-11", Role = "Operador", Status = EmployeeStatus.Active, HireDate = DateTime.UtcNow.AddYears(-1) },
                new() { Name = "Aryane Caroline", Cpf = "222.222.222-22", Role = "Analista", Status = EmployeeStatus.OnVacation, HireDate = DateTime.UtcNow.AddYears(-2) },
                new() { Name = "José Neto", Cpf = "333.333.333-33", Role = "Motorista", Status = EmployeeStatus.Active, HireDate = DateTime.UtcNow.AddYears(-3) }
            };
            await context.Employee.AddRangeAsync(employees);
            await context.SaveChangesAsync();
            Console.WriteLine("[Seeder] Created 3 seed Employees.");
        }

        var housings = await context.Housing.ToListAsync();
        if (!housings.Any())
        {
            var address = new Address { Street = "Rua A", Number = "100", Neighborhood = "Bairro A", City = "Cidade A", State = "SP", ZipCode = "12345-678" };
            await context.Address.AddAsync(address);
            await context.SaveChangesAsync();

            housings = new List<Housing>
            {
                new() { Name = "Alojamento A", MaxCapacity = 10, AddressId = address.Id },
                new() { Name = "Alojamento B", MaxCapacity = 15, AddressId = address.Id },
                new() { Name = "Alojamento C", MaxCapacity = 8, AddressId = address.Id }
            };
            await context.Housing.AddRangeAsync(housings);
            await context.SaveChangesAsync();
            Console.WriteLine("[Seeder] Created 3 seed Housings.");
        }

        var vehicles = await context.Vehicle.ToListAsync();
        if (!vehicles.Any())
        {
            var vehicleModel1 = new VehicleModel { Manufacturer = "Mercedes-Benz", Model = "Sprinter", Type = VehicleType.Van, Year = 2022, FuelType = FuelType.Diesel, MaxCapacity = 16 };
            var vehicleModel2 = new VehicleModel { Manufacturer = "Volkswagen", Model = "POLO", Type = VehicleType.Car, Year = 2023, FuelType = FuelType.Flex, MaxCapacity = 5 };
            await context.VehicleModel.AddRangeAsync(vehicleModel1, vehicleModel2);
            await context.SaveChangesAsync();

            vehicles = new List<Vehicle>
            {
                new() { LicensePlate = "LWUW-7M3", VehicleModelId = vehicleModel1.Id, ChassisNumber = "12345678901234567", Mileage = 15000, Status = VehicleStatus.Available, VehicleCondition = VehicleCondition.New },
                new() { LicensePlate = "KYDJ-3J2", VehicleModelId = vehicleModel2.Id, ChassisNumber = "98765432109876543", Mileage = 5000, Status = VehicleStatus.Available, VehicleCondition = VehicleCondition.New },
                new() { LicensePlate = "ABC-1234", VehicleModelId = vehicleModel2.Id, ChassisNumber = "11111111111111111", Mileage = 80000, Status = VehicleStatus.Maintenance, VehicleCondition = VehicleCondition.PreOwned }
            };
            await context.Vehicle.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();
            Console.WriteLine("[Seeder] Created 2 seed Vehicles.");
        }

        var empCarlos = await context.Employee.FirstOrDefaultAsync(e => e.Name.Contains("Carlos"));
        var empAryane = await context.Employee.FirstOrDefaultAsync(e => e.Name.Contains("Aryane"));
        var empJose = await context.Employee.FirstOrDefaultAsync(e => e.Name.Contains("José"));

        var housA = await context.Housing.FirstOrDefaultAsync(h => h.Name.Contains("Alojamento A"));
        var housB = await context.Housing.FirstOrDefaultAsync(h => h.Name.Contains("Alojamento B"));
        var housC = await context.Housing.FirstOrDefaultAsync(h => h.Name.Contains("Alojamento C"));

        var vehSprinter = await context.Vehicle.FirstOrDefaultAsync(v => v.LicensePlate == "LWUW-7M3");
        var vehPolo = await context.Vehicle.FirstOrDefaultAsync(v => v.LicensePlate == "KYDJ-3J2");

        var baseDate = new DateTime(2026, 05, 12, 14, 30, 00, DateTimeKind.Utc);

        var movements = new List<Movement>
        {
            new()
            {
                Type = MovementType.HousingTransfer,
                Title = "Transferência de Alojamento",
                Description = $"Funcionário <b>{(empCarlos?.Name ?? "Carlos Santos")}</b> transferido de <b>{(housA?.Name ?? "Alojamento A")}</b> para <b>{(housB?.Name ?? "Alojamento B")}</b>",
                StatusLabel = "Transferido",
                CreatedAt = baseDate,
                EmployeeId = empCarlos?.Id,
                HousingId = housB?.Id
            },
            new()
            {
                Type = MovementType.VehicleTripStarted,
                Title = "Viagem iniciada",
                Description = $"Veículo <b>{(vehSprinter?.LicensePlate ?? "LWUW-7M3")} (Sprinter)</b> iniciou a viagem",
                StatusLabel = "Em andamento",
                CreatedAt = baseDate.AddMinutes(-75),
                VehicleId = vehSprinter?.Id
            },
            new()
            {
                Type = MovementType.EmployeeStatusChange,
                Title = "Alteração de Status",
                Description = $"Status de <b>{(empAryane?.Name ?? "Aryane Caroline")}</b> alterado de Ativo para <b>De Férias</b>",
                StatusLabel = "De Férias",
                CreatedAt = baseDate.AddMinutes(-165),
                EmployeeId = empAryane?.Id
            },
            new()
            {
                Type = MovementType.VehicleTripCompleted,
                Title = "Viagem Finalizada",
                Description = $"Veículo <b>{(vehPolo?.LicensePlate ?? "KYDJ-3J2")} (POLO)</b> finalizou a viagem",
                StatusLabel = "Concluída",
                CreatedAt = baseDate.AddMinutes(-250),
                VehicleId = vehPolo?.Id
            },
            new()
            {
                Type = MovementType.HousingTransfer,
                Title = "Transferência de Alojamento",
                Description = $"Funcionário <b>{(empJose?.Name ?? "José Neto")}</b> transferido de <b>{(housC?.Name ?? "Alojamento C")}</b> para <b>{(housB?.Name ?? "Alojamento B")}</b>",
                StatusLabel = "Transferido",
                CreatedAt = baseDate.AddMinutes(-330),
                EmployeeId = empJose?.Id,
                HousingId = housB?.Id
            },
            new()
            {
                Type = MovementType.HousingCheckIn,
                Title = "Novo Funcionário Adicionado ao Alojamento",
                Description = $"O funcionário <b>{(empJose?.Name ?? "José Neto")}</b> foi alocado no <b>{(housA?.Name ?? "Alojamento A")}</b>",
                StatusLabel = "Transferido",
                CreatedAt = baseDate.AddMinutes(-330),
                EmployeeId = empJose?.Id,
                HousingId = housA?.Id
            }
        };

        await context.Movement.AddRangeAsync(movements);
        await context.SaveChangesAsync();
        Console.WriteLine("[Seeder] Created 6 seed Movements matching the screen image!");
    }
}
