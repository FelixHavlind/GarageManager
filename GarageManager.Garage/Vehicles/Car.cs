namespace GarageManager.Garage.Vehicles;

public sealed class Car(string registrationNumber, string color, string manufacturer) : Vehicle(registrationNumber, color)
{
    public string Manufacturer { get; init; } = manufacturer;

    public override string ToString()
    {
        return $"{GetType().Name}: " + base.ToString() + $", {Manufacturer}";
    }
}