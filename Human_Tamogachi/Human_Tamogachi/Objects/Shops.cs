using System.Globalization;

namespace Human_Tamagotchi.Objects;

public class Shops
{
   protected string ShopName;
   protected float[] ShopPrices;
   protected int Page = 0;

   protected void Draw()
   {
       Console.Clear();
       Console.ForegroundColor = ConsoleColor.Green;
       
       Console.SetCursorPosition(20, 2);
       Console.Write("||" + new string('=', 90) + "||");
       Console.SetCursorPosition(20, 4);
       Console.Write("||" + new string('=', 90) + "||");
       Console.SetCursorPosition(20, 6);
       Console.Write("||" + new string('-', 90) + "||");
       Console.SetCursorPosition(20, 18);
       Console.Write("||" + new string('=', 90) + "||");
       Console.SetCursorPosition(20, 20);
       Console.Write("||" + new string('=', 90) + "||");
       
       for (int i = 2; i < 21; i++)
       {
           Console.SetCursorPosition(20, i);
           Console.Write("||");
           Console.SetCursorPosition(112, i);
           Console.Write("||");

           if (i > 3)
           {
               Console.SetCursorPosition(80, i);
               Console.Write("||");
           }
           
       }
       
       Console.SetCursorPosition(57, 3);
       Console.Write("{0, 15}", ShopName);
   }

  
}

public class FoodShop : Shops
{
    private Food[] Items =
    [
        new Food("Pizza", "Fat", 20, 25), new Food("Banana", "FruitAndVeg", 50, 5), new Food("Bread", "Carb", 30, 10),
        new Food("Chicken", "Protein", 10, 15), new Food("Haribo", "Sugar", 150, 1) , new Food("Sandwich", "Carb", 3, 10),
        new Food("test", "test", 999, 999), new Food("test", "test", 999, 999), new Food("test", "test", 999, 999),
        new Food("test", "test", 999, 999), new Food("test", "test", 999, 999), new Food("test", "test", 999, 999),
        new Food("test", "test", 999, 999), new Food("test", "test", 999, 999), new Food("test", "test", 999, 999)
    ];
    private int ItemsTop;

    public FoodShop(string shopName)
    {
        ShopName = shopName;
        ShopPrices = [10, 1, 4, 6, 0.1f, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1];
        ItemsTop = Items.Length;
    }

    private void RemoveItem(int pos)
    {
        for (int i = pos; i < ItemsTop - 1; i++)
        {
            Items[i] = Items[i + 1];
     
            if (i + 2  == ItemsTop)
            {
                Items[i + 1] = null;
                break;
            }
               
        }
            
        if (pos == ItemsTop - 1)
        {
            Items[pos] = null;
        }

        ItemsTop--;
    }
    
    private void RemoveEmptyItem()
    {
        for (int i = 0; i < ItemsTop; i++)
        {
            if (Items[i].ReturnAmount() == 0)
            {
                RemoveItem(i);
            }
        }
    }

    public void Shop(Human Entity, string[] headers, int page, Display UI)
    {
        
        Draw();
        
        int Item = 0;
        int MaxPages = Items.Length / 10;
       
        while (true)
        {
            int pos = 7;
            
            RemoveEmptyItem();
           
            Console.SetCursorPosition(23, 5);
            Console.Write($"Items({Page + 1}/{MaxPages + 1})");
            Console.SetCursorPosition(83, 5);
            Console.Write("Price");
            Console.SetCursorPosition(23, 19);
            Console.Write("Select Item (\u2191/\u2193) || Select Page (\u2190/\u2192)");
            Console.SetCursorPosition(83, 19);

            if (Entity.GetMoney() == (int)Entity.GetMoney())
            {
                Console.Write($"Balance : {Entity.GetMoney()}");
            }
            else
            {
                Console.Write($"Balance : {Entity.GetMoney()}0");
            }
            
            
            for (int i = Page * 10; i <= Page * 10 + 10; i++, pos++)
            {
                if (i == Item)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(23, pos);
                    Console.Write("{0,-55}", Items[i].Display());
                    Console.SetCursorPosition(83, pos);
                    Console.Write("{0,-5}", ShopPrices[i]);
                }
                else if (i >= ItemsTop)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(23, pos);
                    Console.Write(new string(' ', 55));
                    Console.SetCursorPosition(83, pos);
                    Console.Write(new string(' ', 5)); 
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(23, pos);
                    Console.Write("{0,-55}", Items[i].Display());
                    Console.SetCursorPosition(83, pos);
                    Console.Write("{0,-5}", ShopPrices[i]);
                    
                }
                
            }
            
            Console.SetCursorPosition(0,0);
            
            var Key = Console.ReadKey(true);

            if (Key.Key == ConsoleKey.DownArrow && Item < Page * 10 + 10 && Item < ItemsTop - 1)
            {
                Item++;
            } 
            else if (Key.Key == ConsoleKey.UpArrow && Item > Page * 10)
            {
                Item--;
            }
            else if (Key.Key == ConsoleKey.RightArrow && Page < MaxPages)
            {
                Page++;
                Item = Page * 10;
            }
            else if (Key.Key == ConsoleKey.LeftArrow && Page > 0)
            {
                Page--;
                Item = Page * 10;
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                if (Entity.GetMoney() >= ShopPrices[Item])
                {
                    Food ItemClone = (Food) Items[Item].Clone();
                    ItemClone.AddAmount(-(ItemClone.ReturnAmount() - 1));
                    Entity.AddFood(ItemClone);
                    Entity.AddMoney(-ShopPrices[Item]);
                    Items[Item].AddAmount(-1);
                    Console.Clear();
                    Console.SetCursorPosition(65, 5);
                    Console.Write($"You Spent {ShopPrices[Item]} on {Items[Item].Name}.");
                    Thread.Sleep(250);
                    Draw();
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 5);
                    Console.Write("Insufficient Funds.");
                    Thread.Sleep(250);
                    Draw();
                }
            } 
            else if (Key.Key == ConsoleKey.Backspace)
            {
                break;
            }
        }
        
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        UI.FullDraw(headers, page);
    }
}