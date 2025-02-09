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

   public void Draw(int pad, int startPos, int page)
   {
      int startItem = (page - 1) * 10;
      
      for (int i = 0; i < 10; i++, startItem++)
      {
         Console.SetCursorPosition(startPos, i + 2);

         try
         { 
            Console.WriteLine("||" + new string(' ' , pad) + $"ItemSlot({startItem + 1}) {FoodInventory[startItem].Display()}");
         }
         catch (Exception e)
         {
            Console.WriteLine(" ");
         }
         
         
         
        
       
        
      }
   }

}