using System.Runtime.InteropServices.ComTypes;

namespace Human_Tamagotchi.Objects;

public class Display(Human entity)
{
    private Human Entity { get; set; } = entity;
    private const int GAP = 60;
    private const int PADDING = GAP / 2 + 1;
    private string[] HEADERS = new string[] { "Stats", "Health", "Inventory" };

    public void Draw()
    {
        Console.Clear();
        Console.WriteLine("||" + new string('-' , GAP ) + "||" + new string('-' , GAP) + "||" + new string('-' , GAP) + "||");
        Console.Write("||");
        foreach (string header in HEADERS)
        {
            Console.Write(new string(' ', PADDING - header.Length + 1) + header + new string(' ', PADDING - 3) + "||");
        }
        Entity.Draw(GAP / 20);
        Entity.DrawHealth(GAP / 20, GAP + 2);
        Entity.DrawInventory(GAP /20, (2*GAP) + 4);
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 0; j <= 9; j++)
            {
                Console.SetCursorPosition((i*GAP) + (i * 2), j + 2);
                Console.Write("||");
            }
            
        }
        Console.SetCursorPosition(0, 12);
        Console.WriteLine("||" + new string('-' , GAP ) + "||" + new string('-' , GAP) + "||" + new string('-' , GAP) + "||");
        for (int i = 0; i <= 1; i++)
        {
            Console.WriteLine("||" + new string(' ', (3 * GAP) + (2 * 2)) + "||");
            Console.WriteLine("||" + new string('-', (3 * GAP) + (2 * 2)) + "||");
        }
        Console.SetCursorPosition(4, 13);
        Console.Write("Eat(E) Buy(B)");
        Console.SetCursorPosition(4, 15);
    }
}