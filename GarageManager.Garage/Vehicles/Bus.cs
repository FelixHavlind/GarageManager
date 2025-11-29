namespace GarageManager.Garage.Vehicles;

public class Bus(string registrationNumber, string color, int passengerCapacity) : Vehicle(registrationNumber, color)
{
    private int PassengerCapacity { get; } = passengerCapacity;

    public override string ToString()
    {
        return $"{GetType().Name}: " + base.ToString() + $", {PassengerCapacity}";
    }
    
    public override bool Contains(string prompt)
    {
        return $"{PassengerCapacity}".Contains(prompt, StringComparison.CurrentCultureIgnoreCase) || base.Contains(prompt);
    }
}