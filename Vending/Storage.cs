namespace Vending;

public class Storage
{
   private int sugar;
   private int sticks;
   private int coffee;
   private int juice;
   
   public Storage()
   {
      sugar = 20;
      sticks = 100;
      coffee = 50;
      juice = 200;
   }
   
   public bool StickAvailable => sticks > 0;
   public bool SugarAvailable => sugar > 0;
   public bool JuiceAvailable => juice > 0;
   public bool CoffeeAvailable => coffee > 0;

   public void TakeSugar(int quantity) => sugar =- quantity;
   public void TakeStick() => sticks--;
   public void TakeJuice() => juice--;
   public void TakeCoffee() => coffee--;
}
