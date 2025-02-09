// See https://aka.ms/new-console-template for more information

using Human_Tamagotchi;
using Human_Tamagotchi.Objects;

Human human01 = new Human("Adam");
human01.SetAgeTestTool(16);
human01.setLunchBox(true);
for (int i = 0; i < 25; i++)
{
    human01.AddFood(new Food("test", "test", 9999, 9999));
}

Display UI = new Display(human01);

int page = 1;
int Maxpage = 3;


UI.Draw(["-Stats-", "-Health-", $"-Inventory ({page}/{Maxpage})-"], page);
while (true)
{
   
    var inputKey = Console.ReadKey();
    if (inputKey.Key == ConsoleKey.RightArrow && page < Maxpage)
    {
        page++;
        UI.Draw(["-Stats-", "-Health-", $"-Inventory ({page}/{Maxpage})-"], page);
    }
    else if (inputKey.Key == ConsoleKey.LeftArrow && page > 1)
    {
        page--;
        UI.Draw(["-Stats-", "-Health-", $"-Inventory ({page}/{Maxpage})-"], page);
    }
    
   
    
}



