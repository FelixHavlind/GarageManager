using GarageManager.Garage;
using GarageManager.Garage.Interfaces;
using GarageManager.Garage.Vehicles;

namespace GarageManager;

public static class Program
{
    private static void Main(string[] args)
    {
        IGarage<Car> garage = new Garage<Car>(10);
        Console.WriteLine(garage.VehicleCount);
        garage.AddVehicle(new Car("ABC123"));
        Console.WriteLine(garage.VehicleCount);
    }
}