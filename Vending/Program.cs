using Vending.ValueObjects;

namespace CoffeeShopKata.Vending;

public static class Program
{
    public static void Main(string[] args)
    {
           Menu.MenuAvailabilityChanged();
            // Walk up to vending machine and TAPS screen!
           Menu.PrintBeverageMenu();
    }
}
