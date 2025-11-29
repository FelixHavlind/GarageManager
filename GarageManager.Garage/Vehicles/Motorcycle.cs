namespace GarageManager.Garage.Vehicles;

public class Motorcycle(string registrationNumber, string color, string handlebarType) : Vehicle(registrationNumber, color)
{
    private string HandlebarType { get; } = handlebarType;

    public override string ToString()
    {
        return $"{GetType().Name}: " + base.ToString() + $", {HandlebarType}";
    }
    
    public override bool Contains(string prompt)
    {
        return HandlebarType.Contains(prompt, StringComparison.CurrentCultureIgnoreCase) || base.Contains(prompt);
    }
}