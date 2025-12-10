using System.Text;
using GarageManager.Garage.Interfaces;
using GarageManager.Garage.Vehicles;

namespace GarageManager.Garage;

public class GarageHandler : IGarageHandler
{
    private IGarage<Vehicle> _garage = new Garage<Vehicle>(10);
    
    public int VehicleCount => _garage.VehicleCount;
    public int Capacity => _garage.Capacity;

    public void CreateGarage(int capacity, bool populate)
    {
        _garage = new Garage<Vehicle>(capacity);

        if (!populate)
        {
            return;
        }
        
        _garage.AddVehicle(new Airplane("ABC123", "Green", 46.5));
        _garage.AddVehicle(new Boat("CDE234", "Red", "Flat"));
        _garage.AddVehicle(new Bus("RFG345", "Yellow", 32));
        _garage.AddVehicle(new Car("CAS321", "Teal", 300));
        _garage.AddVehicle(new Motorcycle("LES264", "Black", "Ape-hangers"));
    }

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