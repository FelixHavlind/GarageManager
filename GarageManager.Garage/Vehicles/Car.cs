namespace GarageManager.Garage.Vehicles;

public class Car(string registrationNumber) : Vehicle
{
    public sealed override string RegistrationNumber { get; init; } = registrationNumber;
}