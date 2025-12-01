namespace GarageManager.Console;

public interface IUi
{
    void Clear();
    
    int GetInputAsInteger();
    string GetInputAsString();
    bool ValidRegistrationNumber(string registrationNumber);
    
    void PrintMainMenu();
    void PrintAddVehicle();
    void PrintExit();
    void PrintText(string prompt);
    void PrintText(string[]? prompts);
}