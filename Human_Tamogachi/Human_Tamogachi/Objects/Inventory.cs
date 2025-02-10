namespace Human_Tamagotchi.Objects;

public class Inventory
{
   private Food[] FoodInventory = new Food[25];
   private int FoodTop = 0;
   public void StoreFood(Food food, bool HasLunchBox)
   {
      (bool isTrue, int Pos) Stack = inInventory(food.Name);

      if (Stack.isTrue)
      {
         FoodInventory[Stack.Pos].AddAmount(food.ReturnAmount());
      }
      else if (HasLunchBox)
      {
         if (FoodTop < FoodInventory.Length)
         {
            FoodInventory[FoodTop] = food;
            FoodTop++;
         }
      }
      else
      {
         if (FoodTop < 10)
         { 
            FoodInventory[FoodTop] = food;
            FoodTop++;
         }
        
      }
   }

   private (bool, int) inInventory(string name)
   {
      for (int i = 0; i < FoodTop; i++)
      {
         if (FoodInventory[i].Name == name && FoodInventory[i].ReturnAmount() < 20)
         {
            return (true, i);
         }
      }
      
      return (false, 0);
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

   private void RemoveEmptyFood()
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
               Console.SetCursorPosition(60, i + 1);
               Console.Write("{0,-55}",FoodInventory[i].Display());
            }
            else
            {
              
               Console.ResetColor();
               Console.ForegroundColor = ConsoleColor.Green;
               Console.SetCursorPosition(60, i + 1);
               Console.Write("{0,-55}", FoodInventory[i].Display());
               
            }

         }
         
         
         Console.ResetColor();
         Console.ForegroundColor = ConsoleColor.Green;
         
         var key = Console.ReadKey(true);
         
         if (key.Key == ConsoleKey.DownArrow && item < FoodTop - 1)
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
            
            RemoveEmptyFood();
            
         }
         else if (key.Key == ConsoleKey.Backspace)
         {
            break;
         }
      }
      
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Green;
      UI.FullDraw(headers, page);
   }

}