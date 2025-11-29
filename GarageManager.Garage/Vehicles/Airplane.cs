namespace GarageManager.Garage.Vehicles;

public class Airplane(string registrationNumber, string color, double wingSpan) : Vehicle(registrationNumber, color)
{
    private double WingSpan { get; } = wingSpan;

    public override string ToString()
    {
        return $"{GetType().Name}: " + base.ToString() + $", {WingSpan}";
    }
    
    public override bool Contains(string prompt)
    {
        return $"{WingSpan}".Contains(prompt, StringComparison.CurrentCultureIgnoreCase) || base.Contains(prompt);
    }
}