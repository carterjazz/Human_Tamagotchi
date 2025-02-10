using System.Runtime.InteropServices.ComTypes;

namespace Human_Tamagotchi.Objects;

public class Display(Human entity)
{
    private Human Entity { get; set; } = entity;
    private const int GAP = 60;

    private string[] TITLE =
        ["    __  __                               ______                                  __       __    _ ", 
            "   / / / /_  ______ ___  ____ _____     /_  __/___ _____ ___  ____ _____ _____  / /______/ /_  (_)",
            "  / /_/ / / / / __ `__ \\/ __ `/ __ \\     / / / __ `/ __ `__ \\/ __ `/ __ `/ __ \\/ __/ ___/ __ \\/ / ",
            " / __  / /_/ / / / / / / /_/ / / / /    / / / /_/ / / / / / / /_/ / /_/ / /_/ / /_/ /__/ / / / /  ",
            "/_/ /_/\\__,_/_/ /_/ /_/\\__,_/_/ /_/    /_/  \\__,_/_/ /_/ /_/\\__,_/\\__, /\\____/\\__/\\___/_/ /_/_/   ",
            "                                                                 /____/                           "
        ];


    public void FullDraw(string[] headers, int page) 
    {
        DrawMain();
        DrawTitle();
        DrawBody(headers, page);
    }
    public void DrawTitle()
    {
        int down = 1;
        
        foreach (string line in TITLE)
        {   
            Console.SetCursorPosition(45, down);
            Console.Write(line);
            down++;
        }
    }       
    public void DrawMain()
    {
        Console.Clear();
        Console.WriteLine("||" + new string('=', (3*GAP) + 4 ) + "||");
        for (int i = 0; i <= 5; i++)
        {
            Console.SetCursorPosition(0, i + 1);
            Console.Write("||");
            Console.SetCursorPosition((3*GAP) + 6, i + 1);
            Console.Write("||");
        }

        Console.WriteLine();
        Console.WriteLine("||" + new string('=' , GAP ) + "||" + new string('=' , GAP) + "||" + new string('=' , GAP) + "||");
        Console.WriteLine("||" + new string(' ' , GAP ) + "||" + new string(' ' , GAP) + "||" + new string(' ' , GAP) + "||");
 
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 0; j <= 9; j++)
            {
                Console.SetCursorPosition((i*GAP) + (i * 2), j + 9);
                Console.Write("||");
            }
            
        }
        Console.SetCursorPosition(0, 19);
        Console.WriteLine("||" + new string('=' , GAP ) + "||" + new string('=' , GAP) + "||" + new string('=' , GAP) + "||");
        for (int i = 0; i <= 1; i++)
        {
            Console.WriteLine("||" + new string(' ', (3 * GAP) + (2 * 2)) + "||");
            Console.WriteLine("||" + new string('=', (3 * GAP) + (2 * 2)) + "||");
        }
        
    }

    public void DrawBody(string[] HEADERS, int page)
    {
        for (int i = 0; i < HEADERS.Length; i++)
        {
            Console.SetCursorPosition((i * GAP) + (i * 2) + 2, 8);
            Console.Write("{0,37}", HEADERS[i]);
        }


        Entity.Draw(GAP / 20);
        Entity.DrawHealth(GAP / 20, GAP + 4);
        Entity.DrawInventory(GAP /20, (2*GAP) + 8, page);
        
        Console.SetCursorPosition(3, 20);
        Console.Write("Eat (E) ||  Shop (S)");
        Console.SetCursorPosition(3,22);
    }
}