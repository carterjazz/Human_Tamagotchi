// See https://aka.ms/new-console-template for more information

using Human_Tamagotchi;
using Human_Tamagotchi.Objects;

void Initialise(Human human)
{
    human.DrawStats();
    
    while (true)
    {
        string userInput = Console.ReadLine().ToUpper();

        switch (userInput)
        {
            case "H":
                human.DrawHealth();
                break;
            
            case "S":
                human.DrawStats();
                break;
            
            default:
                break;
        }
    }
}

Tests test = new Tests();
