namespace Human_Tamagotchi.Objects;

public class Inventory : Box
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
      
      Console.Clear();
      DrawBox();
      
      int Item = 0;
      int Page = 0;
      int MaxPages = FoodTop / 10;
      
      Console.SetCursorPosition(23, 19);
      Console.Write("Select Item (\u2190/ \u2192) || Select Page (\u2191/\u2193)");
      while (true)
      {
         Console.SetCursorPosition(98, 19);
         Console.Write($"Hunger : {health.GetHunger()}");
         Console.SetCursorPosition(59, 3);
         Console.Write("{0, 15}", $"Inventory ({Page + 1}/{MaxPages + 1})");
         
         int pos = 6;
         
         Console.ResetColor();
         Console.ForegroundColor = ConsoleColor.Green;
         
         for (int i = Page * 10; i <= Page * 10 + 10; i++, pos++)
         {
            if (i == Item && i < FoodTop)
            {
               Console.ForegroundColor = ConsoleColor.Black;
               Console.BackgroundColor = ConsoleColor.White;
               Console.SetCursorPosition(23, pos);
               Console.Write("{0,-55}", FoodInventory[i].Display());
               
            }
            else if (i >= FoodTop)
            {
               Console.ResetColor();
               Console.ForegroundColor = ConsoleColor.Green;
               Console.SetCursorPosition(23, pos);
               Console.Write(new string(' ', 70));
               
            }
            else
            {
               Console.ResetColor();
               Console.ForegroundColor = ConsoleColor.Green;
               Console.SetCursorPosition(23, pos);
               Console.Write("{0,-55}", FoodInventory[i].Display());
               
                    
            }
                
         }

         Console.SetCursorPosition(0, 0);
         
         var key = Console.ReadKey(true);
         
         if (key.Key == ConsoleKey.DownArrow && Item < FoodTop - 1)
         {
            Item++;
         }
         else if (key.Key == ConsoleKey.UpArrow && Item > 0)
         {
            Item--;
         }
         else if (key.Key == ConsoleKey.RightArrow && Page < MaxPages)
         {
            Page++;
            Item = Page * 10;
         }
         else if (key.Key == ConsoleKey.LeftArrow && Page > 0)
         {
            Page--;
            Item = Page * 10;
         }
         else if (key.Key == ConsoleKey.Enter)
         {
            if (FoodInventory[Item] != null)
            {
               FoodInventory[Item].Eat(health);
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