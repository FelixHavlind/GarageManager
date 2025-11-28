using System.Collections;
using GarageManager.Garage.Interfaces;

namespace GarageManager.Garage;

public class Garage<T>(int capacity) : IGarage<T> where T : Vehicle
{
    public int Capacity { get; } = capacity; 
    private readonly T[] _vehicles = new T[capacity];
    public int VehicleCount { get; private set; }
    
    // METHOD
    public void AddVehicle(T vehicle)
    {
        if (Capacity == VehicleCount)
        {
            throw new InvalidOperationException("Garage is full");
        }
        
        _vehicles[VehicleCount++] = vehicle;
    }
    public void RemoveVehicle(T vehicle)
    {
        RemoveVehicle(vehicle.RegistrationNumber);
    }
    public void RemoveVehicle(string registrationNumber)
    {
        var indexFound = false;
        
        for (var i = 0; i < VehicleCount; i++)
        {
            if (_vehicles[i].RegistrationNumber == registrationNumber)
            {
                indexFound = true;
            }

            if (indexFound && i < VehicleCount - 1)
            {
                _vehicles[i] = _vehicles[i + 1];
            }
        }

        if (!indexFound)
        {
            throw new InvalidOperationException("Vehicle not found in garage");
        }
        
        VehicleCount--;
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