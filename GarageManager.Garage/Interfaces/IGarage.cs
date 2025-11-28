namespace GarageManager.Garage.Interfaces;

public interface IGarage<T> : IEnumerable<T> where T : Vehicle
{
    void AddVehicle(T vehicle);
    void RemoveVehicle(T vehicle);
    int VehicleCount { get; }
}