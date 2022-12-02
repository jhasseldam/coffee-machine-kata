namespace Vending.Models;

public class Beverage 
{
    public BeverageType Type { get; set; }
    public int Id { get; set; }
    public decimal Price { get; set; }
}