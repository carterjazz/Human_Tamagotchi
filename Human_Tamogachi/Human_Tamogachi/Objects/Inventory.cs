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

   public void Draw(int pad, int startPos)
   {
      for (int i = 0; i < FoodTop; i++)
      {
         Console.SetCursorPosition(startPos, i + 2);
         Console.WriteLine("||" + new string(' ' , pad) + $"Item#{i + 1} : {FoodInventory[i].Display()}");
      }
   }

}