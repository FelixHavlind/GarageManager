using System.Text;
using GarageManager.Garage.Interfaces;

namespace GarageManager.Garage;

public class GarageHandler(int capacity) : IGarageHandler
{
    private readonly IGarage<Vehicle> _garage = new Garage<Vehicle>(capacity);
    public int VehicleCount => _garage.VehicleCount;
    public int Capacity => _garage.Capacity;

    public void EnterGarage(Vehicle vehicle)
    {
        if (_garage.Contains(vehicle))
        {
            throw new InvalidOperationException($"Vehicle: '{vehicle}', already exist in garage");
        }
        
        _garage.AddVehicle(vehicle);
    }

    public void LeaveGarage(Vehicle vehicle)
    {
        if (!_garage.Contains(vehicle))
        {
            throw new InvalidOperationException($"Vehicle: '{vehicle}', does not exist in garage");
        }
        
        _garage.RemoveVehicle(vehicle);
    }

    public string GetVehicleList()
    {
        var stringBuilder = new StringBuilder();
        
        foreach (var vehicle in _garage)
        {
            stringBuilder.Append(vehicle).Append(Environment.NewLine);    
        }
        
        return stringBuilder.ToString();
    }
}