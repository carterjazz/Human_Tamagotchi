// See https://aka.ms/new-console-template for more information

using Human_Tamagotchi;
using Human_Tamagotchi.Objects;
using Microsoft.VisualBasic;


internal class Program
{
    public static void Main(string[] args)
    {
        
        Console.SetWindowSize(Console.LargestWindowWidth - 52, Console.LargestWindowHeight - 20);
        Console.Title = "Human Tamagotchi";

        
        Human human01 = new Human("Adam");
        FoodShop foodShop = new FoodShop("Megastore");
        JobCenter jobCenter01 = new JobCenter([new Job("TEST", "TEST", 1,2,300), new Job("TEST2", "TEST2", 1,2,300)], "Center1");
        JobCenter jobCenter02 = new JobCenter([new Job("TEST", "TEST", 1, 2, 300)], "Center2");
        JobMenu jobMenu = new JobMenu([jobCenter01, jobCenter02]);
        
        human01.SetAge(0);
        human01.setLunchBox(true);
        human01.AddMoney(9999999f);
        for (int i = 0; i < 25; i++)
        {
            human01.AddFood(new Food("TEST", "TEST", 20, 10));
        }
        

        Display UI = new Display(human01);


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
            else if (inputKey.Key == ConsoleKey.S)
            {
                foodShop.Shop(human01, ["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page, UI);
            }
            else if (inputKey.Key == ConsoleKey.Spacebar)
            {
                human01.IncreaseDay();
                UI.DrawBody(["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page); 
            }
            else if (inputKey.Key == ConsoleKey.Y)
            {
                human01.IncreaseYear();
                UI.DrawBody(["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page); 
            }
            else if (inputKey.Key == ConsoleKey.J)
            {
                jobMenu.JobsMenu(human01, ["-STATS-     ", "-HEALTH-   ", $"-INVENTORY ({page}/{Maxpage})-"], page, UI);
            } 
           
           
        }
    }
}





