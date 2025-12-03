using GarageManager.Console;
using GarageManager.Garage;
using GarageManager.Garage.Interfaces;
using GarageManager.Garage.Vehicles;

namespace GarageManager;

public static class GarageManager
{
    private static readonly IUi Ui = new ConsoleUi();
    private static readonly IGarageHandler GarageHandler = new GarageHandler();
        
    public static int Start()
    {
        var running = true;
        
        do
        {
            Ui.Clear();
            Ui.PrintMainMenu();

            switch (Ui.GetInputAsInteger())
            {
                case 1: 
                    AddVehicle();
                    break;
                
                case 2:
                    RemoveVehicle();
                    break;
                
                case 3:
                    ListVehicles();
                    break;
                
                case 4:
                    ListVehiclesByType();
                    break;
                
                case 5:
                    SearchVehicle();
                    break;
                
                case 6:
                    CreateNewGarage();
                    break;
                
                case 0:
                    Ui.Clear();
                    Ui.PrintExit();
                    running = false;
                    break;
            }
        } while (running);

        return 0;
    }

    private static void AddVehicle()
    {
        Ui.Clear();
        Ui.PrintAddVehicle();

        switch (Ui.GetInputAsInteger())
        {
            case 1:
            {
                Ui.Clear();
                Ui.PrintText("Enter airplane registration number");
                var registrationNumber = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter airplane color");
                var color = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter airplane wingspan");
                var wingspan = Ui.GetInputAsDouble();
                
                GarageHandler.EnterGarage(new Airplane(registrationNumber, color, wingspan));
                break;
            }
            case 2:
            {
                Ui.Clear();
                Ui.PrintText("Enter boat registration number");
                var registrationNumber = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter boat color");
                var color = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter boat hull type");
                var hullType = Ui.GetInputAsString();
                
                GarageHandler.EnterGarage(new Boat(registrationNumber, color, hullType));
                break;
            }
            case 3:
            {
                Ui.Clear();
                Ui.PrintText("Enter bus registration number");
                var registrationNumber = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter bus color");
                var color = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter bus passenger capacity");
                var passengerCapacity = Ui.GetInputAsInteger();
                
                GarageHandler.EnterGarage(new Bus(registrationNumber, color, passengerCapacity));
                break;
            }
            case 4:
            {
                Ui.Clear();
                Ui.PrintText("Enter car registration number");
                var registrationNumber = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter car color");
                var color = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter car trunk size");
                var trunkSize = Ui.GetInputAsInteger();
                
                GarageHandler.EnterGarage(new Car(registrationNumber, color, trunkSize));
                break;
            }
            case 5:
            {
                Ui.Clear();
                Ui.PrintText("Enter motorcycle registration number");
                var registrationNumber = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter motorcycle color");
                var color = Ui.GetInputAsString();
                
                Ui.Clear();
                Ui.PrintText("Enter motorcycle handlebar type");
                var handlebarType = Ui.GetInputAsString();
                
                GarageHandler.EnterGarage(new Motorcycle(registrationNumber, color, handlebarType));
                break;
            }
        }
    }

    private static void RemoveVehicle()
    {
        Ui.Clear();
        Ui.PrintText("Enter vehicle registration number");
        
        GarageHandler.LeaveGarage(Ui.GetInputAsString());
    }
    
    private static void ListVehicles()
    {
        Ui.Clear();
        var list = GarageHandler.GetVehicleList();

        if (list == null)
        {
            Ui.PrintText("No vehicles found in garage");
        }

        else
        {
            Ui.PrintText(list.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries));
        }
        
        System.Console.ReadKey();
    }
    
    private static void ListVehiclesByType()
    {
        Ui.Clear();
        var list = GarageHandler.GetVehicleTypeList();

        if (list == null)
        {
            Ui.PrintText("No vehicles found in garage");
        }
        
        else
        {
            Ui.PrintText(list.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries));
        }
        
        System.Console.ReadKey();
    }
    
    private static void SearchVehicle()
    {
        Ui.Clear();
        Ui.PrintText("Enter search prompt");
        var list = GarageHandler.SearchVehicle(Ui.GetInputAsString());
        Ui.Clear();
        
        if (list == null)
        {
            Ui.PrintText("No vehicles found in garage");
        }

        else
        {
            Ui.PrintText(list.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries));   
        }
        
        System.Console.ReadKey();
    }

    private static void CreateNewGarage()
    {
        Ui.Clear();
        Ui.PrintText("Enter garage capacity");
        var capacity = Ui.GetInputAsInteger();
        
        Ui.Clear();
        Ui.PrintText("Populate garage? (y/N)");
        var populate = Ui.GetInputAsBool();
        
        GarageHandler.CreateGarage(capacity, populate);
    }
}