namespace GarageManager.Garage.Vehicles;

public class Boat(string registrationNumber, string color, string hullType) : Vehicle(registrationNumber, color)
{
    private string HullType { get; } = hullType;

    public override string ToString()
    {
        return $"{GetType().Name}: " + base.ToString() + $", {HullType}";
    }
    
    public override bool Contains(string prompt)
    {
        return HullType.Contains(prompt, StringComparison.CurrentCultureIgnoreCase) || base.Contains(prompt);
    }
}