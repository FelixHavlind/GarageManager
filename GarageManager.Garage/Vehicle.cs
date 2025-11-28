namespace GarageManager.Garage;

public abstract class Vehicle
{
    public abstract string RegistrationNumber { get; init; }

    public override string ToString()
    {
        return  $"{RegistrationNumber}";
    }
}