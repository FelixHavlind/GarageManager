namespace GarageManager.Garage.Interfaces;

public interface IGarageHandler
{
    int VehicleCount { get; }
    int Capacity { get; }

    void CreateGarage(int capacity, bool populate);
    
    void EnterGarage(Vehicle vehicle);
    void LeaveGarage(Vehicle vehicle);
    void LeaveGarage(string registrationNumber);
    
    string? GetVehicleList();
    string? GetVehicleTypeList();
    string GetVehicle(string registrationNumber);
    
    string? SearchVehicle(string searchPrompt);
}