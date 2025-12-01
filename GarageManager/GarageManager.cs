using GarageManager.Console;
using GarageManager.Garage;
using GarageManager.Garage.Interfaces;

namespace GarageManager;

public static class GarageManager
{
    private static IUi _ui = new ConsoleUi();
    private static IGarageHandler _garageHandler = new GarageHandler(10);
        
    public static int Start()
    {
        var running = true;
        
        do
        {
            _ui.Clear();
            _ui.PrintMainMenu();
        } while (running);

        return 0;
    }
}