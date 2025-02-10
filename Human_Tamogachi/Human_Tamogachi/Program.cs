// See https://aka.ms/new-console-template for more information

using Human_Tamagotchi;
using Human_Tamagotchi.Objects;

Console.SetWindowSize(Console.LargestWindowWidth - 52, Console.LargestWindowHeight - 20);
Console.Title = "Human Tamagotchi";

Human human01 = new Human("Adam");
human01.SetAgeTestTool(0);
human01.setLunchBox(true);
Display UI = new Display(human01);

human01.AddFood(new Food("Garlic Bread", "Carb", 5, 10));
human01.AddFood(new Food("Banana", "Fruit", 3, 15));
for (int i = 0; i < 10; i++)
{
    human01.AddFood(new Food("Pizza", "Fat", 1, 25));
}

int page = 1;
int Maxpage = 3;

Console.ForegroundColor = ConsoleColor.Green;

UI.FullDraw(["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page);

while (true)
{
   
   var inputKey = Console.ReadKey(true);
   
   if (inputKey.Key == ConsoleKey.RightArrow && page < Maxpage)
   {
       page++;
       UI.DrawBody(["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page);
   }
   else if (inputKey.Key == ConsoleKey.LeftArrow && page > 1) 
   {
       page--;
       UI.DrawBody(["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page);
   }
   else if (inputKey.Key == ConsoleKey.E)
   {
       human01.EatFood(["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page, UI);
   }
    
   
    
}



