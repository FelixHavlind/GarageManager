using System.Text.RegularExpressions;

namespace GarageManager.Garage;

public abstract partial class Vehicle
{
    [GeneratedRegex("^[A-z]{3}[0-9]{3}$")]
    private partial Regex ValidRegistrationNumber();
    
    public string RegistrationNumber { get; }
    public string Color { get; }

    protected Vehicle(string registrationNumber, string color)
    {
        if (!ValidRegistrationNumber().IsMatch(registrationNumber))
        {
            throw new ArgumentException("Invalid registration number format");
        }
        
        RegistrationNumber = registrationNumber;
        Color = color;
    }
    
    public bool Equals(Vehicle other)
    {
        return RegistrationNumber == other.RegistrationNumber;
    }
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }
        
        return Equals((Vehicle)obj);
    }
    public override int GetHashCode()
    {
        return RegistrationNumber.GetHashCode();
    }

    public override string ToString()
    {
        return  $"{RegistrationNumber}, {Color}";
    }
}