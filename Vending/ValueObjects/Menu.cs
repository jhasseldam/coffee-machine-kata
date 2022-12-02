using System.Text.Json;

namespace Vending.ValueObjects;

public static class Menu
{
    public static bool CoffeeAvailable { get; private set; }
    public static bool JuiceAvailable { get; private set; }

    // Listen to resources event background process
    private static void MenuAvailabilityChanged()
    {
        var availabilityJson = "{ \"coffee\": true, \"Juice\": false }"; // Example event
        var availability = JsonSerializer.Deserialize<StorageUpdate>(availabilityJson);
        CoffeeAvailable = availability.Coffee;
        JuiceAvailable = availability.Juice;
    }

    public static void PrintMenu()
    {
        Console.WriteLine($"Velcome to the vending machine. Today's selection is:");
        if (CoffeeAvailable) Console.WriteLine("- Coffee");
        if (JuiceAvailable) Console.WriteLine("- Juice");
    }
}