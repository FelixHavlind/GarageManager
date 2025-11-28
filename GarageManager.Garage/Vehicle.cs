namespace GarageManager.Garage;

public abstract class Vehicle
{
    public abstract string RegistrationNumber { get; init; }

    protected bool Equals(Vehicle other)
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
        return  $"{RegistrationNumber}";
    }
}