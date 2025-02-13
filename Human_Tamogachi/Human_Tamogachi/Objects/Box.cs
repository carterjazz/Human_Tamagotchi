namespace Human_Tamagotchi.Objects;

public class Box
{
    protected void DrawBox()
    {
            
            
        Console.Clear();
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
    
        Console.SetCursorPosition(20, 2);
        Console.Write("||" + new string('=', 90) + "||");
        Console.SetCursorPosition(20, 4);
        Console.Write("||" + new string('=', 90) + "||");
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
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;

    }

    protected void DrawTable(string Title)
    {
       
        Console.Clear();
        Console.ResetColor();
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
        Console.Write("{0, 15}", Title);
    } 
    
}