using static System.Text.RegularExpressions.Regex;

namespace GarageManager.Console;

public class ConsoleUi : IUi
{
    private const int Width = 48;

    public void Clear() => System.Console.Clear();
    
    // METHODS
    public int GetInputAsInteger() => int.TryParse(GetInputAsString(), out var integer) ? integer : -1;
    public double GetInputAsDouble() => double.TryParse(GetInputAsString(), out var d) ? d : -1.0;
    public string GetInputAsString() => System.Console.ReadLine() ?? "ERROR_STRING";
    public bool GetInputAsBool() => GetInputAsString() is "Y" or "y";

    public bool ValidRegistrationNumber(string registrationNumber)
    {
        return IsMatch(registrationNumber, "[A-Za-z]{3}\\d{3}$");
    }

    public void PrintMainMenu()
    {
        System.Console.WriteLine(Messages.MenuTop);
        System.Console.WriteLine(Messages.MainMenOptions);
        System.Console.WriteLine(Messages.ExitOption);
        System.Console.WriteLine(Messages.MenuBottom);
    }
    public void PrintAddVehicle()
    {
        System.Console.WriteLine(Messages.MenuTop);
        System.Console.WriteLine(Messages.AddVehicleOptions);
        System.Console.WriteLine(Messages.ExitOption);
        System.Console.WriteLine(Messages.MenuBottom);
    }
    public void PrintExit()
    {
        PrintText("Exiting application...");
    }
    public void PrintText(string prompt)
    {
        System.Console.WriteLine(Messages.MenuTop);
        System.Console.WriteLine(AdjustWidth(prompt));
        System.Console.WriteLine(Messages.MenuBottom);
    }
    public void PrintText(string[] prompts)
    {
        System.Console.WriteLine(Messages.MenuTop);

        foreach (var prompt in prompts)
        {
            System.Console.WriteLine(AdjustWidth(prompt));
        }
        
        System.Console.WriteLine(Messages.MenuBottom);
    }
    
    // PRIVATE
    private string AdjustWidth(string s)
    {
        var sLength = s.Length;
        
        if (Width < sLength)
        {
            throw new NotImplementedException();
        }
        
        var rowOffset = Width - sLength - 4;
        var adjustedString = Messages.MenuCenter;
        adjustedString = adjustedString.Insert(adjustedString.Length - 1, " " + s);
        adjustedString = adjustedString.Insert(adjustedString.Length - 1, string.Concat(Enumerable.Repeat<string>(" ", rowOffset + 1)));
        return adjustedString;
    }
}