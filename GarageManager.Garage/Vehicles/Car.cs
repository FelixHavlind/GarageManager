namespace GarageManager.Garage.Vehicles;

public sealed class Car(string registrationNumber, string color, int trunkSize) : Vehicle(registrationNumber, color)
{
    public int TrunkSize { get; } = trunkSize;

    public override string ToString()
    {
        return $"{GetType().Name}: " + base.ToString() + $", {TrunkSize}";
    }

    public override bool Contains(string prompt)
    {
        return $"{TrunkSize}".Contains(prompt, StringComparison.CurrentCultureIgnoreCase) || base.Contains(prompt);
    }
}