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
        
        if (_vehicles.Contains(vehicle))
        {
            throw new InvalidOperationException($"Vehicle with registration number: '{vehicle.RegistrationNumber}', already exist in garage");
        }
        
        _vehicles[VehicleCount++] = vehicle;
    }
    public void RemoveVehicle(T vehicle)
    {
        if (!_vehicles.Contains(vehicle))
        {
            throw new ArgumentException($"Vehicle with registration number: '{vehicle.RegistrationNumber}', does not exist in garage");
        }
        
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
            throw new ArgumentException($"Vehicle with registration number: '{registrationNumber}', does not exist in garage");
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