using Vending.Models;
using Vending.ValueObjects;

namespace Beverages.Aggregate;

public class VendingMachine
{
   private Selection Selection { get; set; }
   private Beverage _juice;
   private Beverage _coffee;
   
   public VendingMachine()
   {
     // fetch available beverages
     _juice = new Beverage
     {
        Type = BeverageType.Juice,
        Price = 50,
        Id = 1
     };
     _coffee = new Beverage
     {
        Type = BeverageType.Coffee,
        Price = 30,
        Id = 2
     };
   }
   
   public void SelectJuice()
   {
      Selection = new Selection()
      {
         Beverage = _juice,
         Condiments = null
      };
   }
   
   public void SelectCoffee()
   {
      Selection = new Selection()
      {
         Beverage = _coffee,
         Condiments = new List<Condiment>()
      };
      OfferStickIfAvailable();
      OfferSugarIfAvailable();
   }

   private void OfferStickIfAvailable()
   {
      if (Menu.StickAvailable) Console.WriteLine("Would you like a stick with that?");
      var answer = Console.ReadLine();
      if (answer == "y") Selection.Condiments.Add(new Stick());
   }
   
   private void OfferSugarIfAvailable()
   {
      if (Menu.SugarAvailable(1)) Console.WriteLine("How much sugar would you like");
      var sugarAmount = int.Parse(Console.ReadLine());
      if (sugarAmount > 0 && Menu.SugarAvailable(sugarAmount)) Selection.Condiments.Add(new Sugar() { Quantity = sugarAmount});
   }

   public void ConfirmSelection()
   {
      
   }

   private void PaymentSuccessfulEventReceived()
   {
      Console.WriteLine("Here is your order:"); 
   }

   private void PaymentFailureEventReceived()
   {
      Console.WriteLine("Selection cancelled");
      // Reset the selection 
      Menu.PrintBeverageMenu();
   }
}