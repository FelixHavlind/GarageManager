namespace GarageManager.Console;

public static class Messages
{
    public const string MenuTop =
        """
          ┌───────────────────────┐
          │ GARAGE MANAGER v0.1.0 ╞════════════════════════╗
          └─╥─────────────────────┘                        ║
        """;
    public const string MenuCenter =
        """
            ║║
        """;
    public const string MenuBottom =
        """
            ╚══════════════════════════════════════════════╝
        """;

    public const string MainMenOptions =
        """
            ║ (1) Enter a vehicle into the garage          ║
            ║ (2) Exit a vehicle out of the garage         ║
            ║ (3) List all parked vehicles                 ║
            ║ (4) List vehicles by type                    ║
            ║ (5) Search for a parked vehicle              ║
            ║ (6) Create new garage                        ║
        """;
    public const string AddVehicleOptions = 
        """
            ║ (1) Airplane                                 ║
            ║ (2) Boat                                     ║
            ║ (3) Bus                                      ║
            ║ (4) Car                                      ║
            ║ (5) Motorcycle                               ║
        """;

    public const string ExitOption =
        """
            ║                                              ║
            ║ (0) Exit                                     ║
        """;
}