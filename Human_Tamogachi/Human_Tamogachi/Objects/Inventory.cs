namespace Human_Tamagotchi.Objects;

public class Inventory
{
   private Food[] FoodInventory = new Food[25];
   private int FoodTop = 0;
   public void StoreFood(Food food, bool HasLunchBox)
   {
      if (HasLunchBox)
      {
         if (FoodTop < FoodInventory.Length)
         {
            FoodInventory[FoodTop] = food;
            Console.WriteLine($"{food.Name} added ({FoodTop + 1}/{FoodInventory.Length})");
            FoodTop++;
         }
         else
         {
            Console.WriteLine("Inventory is full");
         }
      }
      else
      {
         if (FoodTop < 10)
         { 
            FoodInventory[FoodTop] = food;
            Console.WriteLine($"{food.Name} added ({FoodTop + 1}/10)");
            FoodTop++;
         }
         else
         {
            Console.WriteLine("Inventory is full");
         }
        
      }
   }

   public void Draw()
   {
      Console.WriteLine($"---------- INVENTORY ----------");
      for (int i = 0; i < FoodTop; i++)
      {
         Console.WriteLine($"Food Slot #{i + 1} : {FoodInventory[i].Display()}");
      }
   }
}