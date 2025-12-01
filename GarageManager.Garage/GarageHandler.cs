using System.Text;
using GarageManager.Garage.Interfaces;

namespace GarageManager.Garage;

public class GarageHandler(int capacity) : IGarageHandler
{
    private readonly IGarage<Vehicle> _garage = new Garage<Vehicle>(capacity);
    
    public int VehicleCount => _garage.VehicleCount;
    public int Capacity => _garage.Capacity;

    public void EnterGarage(Vehicle vehicle) => _garage.AddVehicle(vehicle);
    public void LeaveGarage(Vehicle vehicle) => _garage.RemoveVehicle(vehicle);
    public void LeaveGarage(string registrationNumber) => _garage.RemoveVehicle(registrationNumber);

    public string? GetVehicleList()
    {
        if (_garage.VehicleCount == 0)
        {
            return null;
        }
        
        var stringBuilder = new StringBuilder();
        
        foreach (var vehicle in _garage)
        {
            stringBuilder.Append(vehicle).Append(Environment.NewLine);    
        }
        
        return stringBuilder.ToString();
    }
    public string? GetVehicleTypeList()
    {
        if (_garage.VehicleCount == 0)
        {
            return null;
        }
        
        var dictionary = new Dictionary<string, int>();

        foreach (var vehicle in _garage)
        {
            if (!dictionary.TryAdd(vehicle.GetType().Name, 1))
            {
                dictionary[vehicle.GetType().Name]++;
            }
        }

        var stringBuilder = new StringBuilder();
        
        foreach (var s in dictionary)
        {
            stringBuilder.Append(s.Key).Append(": ").Append(s.Value).Append(Environment.NewLine);
        }

        return stringBuilder.ToString();
    }
    public string GetVehicle(string registrationNumber)
    {
        foreach (var vehicle in _garage)
        {
            if (vehicle.RegistrationNumber == registrationNumber)
            {
                return vehicle.ToString();
            }
        }
        
        throw new ArgumentException($"Vehicle with the registration number: {registrationNumber}, does not exist");
    }

    public string? SearchVehicle(string searchPrompt)
    {
        var stringBuilder = new StringBuilder();
        
        foreach (var vehicle in _garage)
        {
            if (vehicle.Contains(searchPrompt))
            {
                stringBuilder.Append(vehicle).Append(Environment.NewLine);
            }
        }

        return stringBuilder.Length > 0 ? stringBuilder.ToString() : null;
    }
}