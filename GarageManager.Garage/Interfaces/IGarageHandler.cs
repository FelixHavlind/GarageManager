namespace GarageManager.Garage.Interfaces;

public interface IGarageHandler
{
    void EnterGarage(Vehicle vehicle);
    void LeaveGarage(Vehicle vehicle);
    int VehicleCount { get; }
    int Capacity { get; }
    string GetVehicleList();
}