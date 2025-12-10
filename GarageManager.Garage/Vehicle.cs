using System.Text.RegularExpressions;

namespace GarageManager.Garage;

public abstract class Vehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }

    protected Vehicle(string registrationNumber, string color)
    {
        if (!Regex.IsMatch(registrationNumber, "^[A-z]{3}\\d{3}$"))
        {
            throw new ArgumentException("Invalid registration number format");
        }
        
        RegistrationNumber = registrationNumber;
        Color = color;
    }

    public virtual bool Contains(string prompt)
    {
        return GetType().Name.Contains(prompt, StringComparison.CurrentCultureIgnoreCase) ||
               RegistrationNumber.Contains(prompt, StringComparison.CurrentCultureIgnoreCase) ||
               Color.Contains(prompt, StringComparison.CurrentCultureIgnoreCase);
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