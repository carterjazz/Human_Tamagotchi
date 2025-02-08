// See https://aka.ms/new-console-template for more information

using Human_Tamagotchi;
using Human_Tamagotchi.Objects;

const string OPTIONS = "------------------------\nStats(S)  || Health(H) || Inventory(I)";
void Initialise(Human human)
{
    Food testFood = new Food("test" , "Carb", 10, 1);
    human.DrawStats();
    Console.WriteLine(OPTIONS);
    
    while (true)
    {
        char userInput = (char) Console.ReadLine().ToUpper()[0];

        switch (userInput)
        {
            case 'H':
                human.DrawHealth();
                break;
            
            case 'S':
                human.DrawStats();
                break;
            
            case 'I':
                human.DrawInventory();
                break;
            
            default:
                testFood.Eat(human.GetHealth());
                Console.WriteLine(testFood.Display());
                break;
        }

        Console.WriteLine(OPTIONS);
    }
}
Human human01 = new Human("Adam");
human01.SetAgeTestTool(18);
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Chocolate", "Sugar", 3, 20));
human01.AddFood(new Food("Cherry", "FruitAndVeg", 50, 3));
human01.AddFood(new Food("Milk", "Dairy", 10, 1));
human01.AddFood(new Food("Pork Scratchings", "Fat", 1, 10));

Initialise(human01);