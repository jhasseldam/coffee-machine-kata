using Vending.ValueObjects;

namespace Vending.Models;

public class Selection
{
    public int Id { get; set; } 
    public Beverage Beverage { get; set;}
    public List<Condiment> Condiments { get; set;} = null!;
}