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
         Console.SetCursorPosition(startPos, i + 9);
         Console.Write(new string(' ', 58));
         Console.SetCursorPosition(startPos, i + 9);

         try
         {
            if (startItem + 1 < 10 && FoodInventory[startItem] != null)
            {
               
               Console.WriteLine(new string(' ' , pad) + $"Item ({startItem + 1}): {FoodInventory[startItem].Display()}");
            }
            else if (FoodInventory[startItem] != null)
            {
               Console.WriteLine(new string(' ' , pad) + $"Item({startItem + 1}): {FoodInventory[startItem].Display()}"); 
            }
            
         }
         catch (Exception)
         {
            Console.WriteLine(new string(' ', 58));
         }
         
      }
   }

   private void RemoveItem(int pos, string inventory)
   {
      switch (inventory)
      {
         case "Food":
            
            for (int i = pos; i < FoodTop - 1; i++)
            {
               FoodInventory[i] = FoodInventory[i + 1];
     
               if (i + 2  == FoodTop)
                    {
                        FoodInventory[i + 1] = null;
                        break;
                    }
               
                       
                       
                   
               
               
               
               
            }
            
            if (pos == FoodTop - 1)
                {
                    FoodInventory[pos] = null;
                }

            FoodTop--;
            
            break;
         
         default:
            break;
      }
   }

   private void FindEmptyFood()
   {
      for (int i = 0; i < FoodTop; i++)
      {
         if (FoodInventory[i].ReturnAmount() == 0)
         {
            RemoveItem(i, "Food");
         }
      }
   }

   public void EatFood(Health health, string[] headers, int page, Display UI)
   {
     
      int item = 0;

      while (true)
      {
         
         Console.Clear();
         for (int i = 0; i < FoodTop; i++)
         {
            if (i == item)
            {
               Console.ForegroundColor = ConsoleColor.Black;
               Console.BackgroundColor = ConsoleColor.White;
               Console.WriteLine(new String(' ', 60) + FoodInventory[i].Display() + new string(' ', 60));
            }
            else
            {
              
               Console.ResetColor();
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine(new String(' ', 60) + FoodInventory[i].Display() + new string(' ', 60));
               
            }

         }
         
         var key = Console.ReadKey(true);
         
         if (key.Key == ConsoleKey.DownArrow && item < FoodInventory.Length - 1)
         {
            item++;
         }
         else if (key.Key == ConsoleKey.UpArrow && item > 0)
         {
            item--;
         }
         else if (key.Key == ConsoleKey.Enter)
         {
                if (FoodInventory[item] != null)
                {
                    FoodInventory[item].Eat(health);
                }
                
            break;
         }
         else if (key.Key == ConsoleKey.Backspace)
         {
            break;
         }
      }
      
      FindEmptyFood();
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Green;
      UI.FullDraw(headers, page);
   }

}