namespace GarageManager.Console;

public interface IUi
{
    void Clear();
    
    int GetInputAsInteger();
    double GetInputAsDouble();
    string GetInputAsString();
    bool GetInputAsBool();
    
    void PrintMainMenu();
    void PrintAddVehicle();
    void PrintExit();
    void PrintText(string prompt);
    void PrintText(string[] prompts);
    string GetInputAsRegistrationNumber();
}