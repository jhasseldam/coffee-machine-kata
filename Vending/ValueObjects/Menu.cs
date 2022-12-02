using System.Text.Json;

namespace Vending.ValueObjects;

public static class Menu
{
    public static bool CoffeeAvailable { get; private set; }
    public static bool JuiceAvailable { get; private set; }
    public static bool StickAvailable { get; private set; }
    private static int SugarQuantity { get; set; }

    public static bool SugarAvailable(int amount)
    {
        return SugarQuantity >= amount;
    }

    // Listen to resources event background process
    public static void MenuAvailabilityChanged()
    {
        var availabilityJson = "{ \"Coffee\": true, \"Juice\": true, \"Sticks\": true, \"Sugar\": 5 }"; // Example event
        var availability = JsonSerializer.Deserialize<StorageUpdate>(availabilityJson);
        CoffeeAvailable = availability.Coffee;
        JuiceAvailable = availability.Juice;
    }

    public static void PrintBeverageMenu()
    {
        Console.WriteLine("Welcome to the vending machine. Today's selection is:");
        if (CoffeeAvailable) Console.WriteLine("- Coffee");
        if (JuiceAvailable) Console.WriteLine("- Juice");
    }
}