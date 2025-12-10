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
    public string GetInputAsRegistrationNumber()
    {
        string registrationNumber;
        
        do
        {
            Clear();
            System.Console.WriteLine(Messages.MenuTop);
            System.Console.WriteLine(AdjustWidth("Enter registration number (ABC123)"));
            System.Console.WriteLine(Messages.MenuBottom);

            registrationNumber = GetInputAsString().Trim();

            if (IsMatch(registrationNumber, "[A-z]{3}\\d{3}$"))
            {
                continue;
            }
            
            Clear();
            System.Console.WriteLine(Messages.MenuTop);
            System.Console.WriteLine(AdjustWidth("Invalid format"));
            System.Console.WriteLine(Messages.MenuBottom);
            System.Console.ReadKey();
        } while (!IsMatch(registrationNumber, "[A-z]{3}\\d{3}$"));

        return registrationNumber;
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
    private static string AdjustWidth(string s)
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