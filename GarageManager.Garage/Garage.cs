using System.Collections;
using GarageManager.Garage.Interfaces;

namespace GarageManager.Garage;

public class Garage<T>(int size) : IGarage<T> where T : Vehicle
{
    private T[] _vehicles = new T[size];
    public int VehicleCount { get; private set; }
    
    public void AddVehicle(T vehicle)
    {
        if (size == VehicleCount)
        {
            throw new InvalidOperationException("Garage is full");
        }
        
        _vehicles[VehicleCount++] = vehicle;
    }

    public void RemoveVehicle(T vehicle)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < VehicleCount; i++)
        {
            yield return _vehicles[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}