namespace Human_Tamagotchi.Objects;


public class JobMenu(JobCenter[] centers) : Box
{
    private JobCenter[] JobCenters = centers;

    private string[,] Options = new string[,] {
        {
            "Quit Job", "Beg for Promotion", "Exit"
        }, {
            "View Job Centers", "Claim Benefits", "Exit"
        }
    };
       
    private int Benefits = 100;
    
    public void JobsMenu(Human entity, string[] headers, int page, Display UI)
    {
        int selectedItem = 0;
        
        
        if (entity.hasJob())
        {
            DrawBox();
            Console.SetCursorPosition(24, 3);
            Console.WriteLine($"Current Job : {entity.Getjob().PrintData()}");

            while (true)
            {
                int pos = 6;
                
                for (int i = 0; i < 3; i++, pos++)
                {
                    if (i == selectedItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(23, pos);
                        Console.Write("{0, -15}", Options[0, i]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(23, pos);
                        Console.Write("{0, -15}", Options[0, i]);
                    }
                }
                Console.SetCursorPosition(0,0);
                
                var Key = Console.ReadKey();

                if (Key.Key == ConsoleKey.DownArrow && selectedItem < 3)
                {
                    selectedItem++;
                }
                else if (Key.Key == ConsoleKey.UpArrow && selectedItem > 0)
                {
                    selectedItem--;
                }
                else if (Key.Key == ConsoleKey.Enter)
                {
                    switch (selectedItem)
                    {
                        case 0:
                            entity.Setjob(null);
                            JobsMenu(entity, headers, page, UI);
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
                }
            }

        }
        else
        {
            DrawBox();
            Console.SetCursorPosition(58, 3);
            Console.WriteLine("UNEMPLOYED");
            
            while (true)
            {
                int pos = 6; 
                for (int i = 0; i < 3; i++, pos++)
                {
                    if (i == selectedItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(23, pos);
                        Console.Write("{0, -15}", Options[1, i]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(23, pos);
                        Console.Write("{0, -15}", Options[1, i]);
                    }
                }
                Console.SetCursorPosition(0,0);
                
                var Key = Console.ReadKey();

                if (Key.Key == ConsoleKey.DownArrow && selectedItem < 3)
                {
                    selectedItem++;
                }
                else if (Key.Key == ConsoleKey.UpArrow && selectedItem > 0)
                {
                    selectedItem--;
                }
                else if (Key.Key == ConsoleKey.Enter)
                {
                    switch (selectedItem)
                    {
                        case 0:
                            SelectJobCenter(entity, headers, page, UI);
                            break;
                        case 1:
                            entity.AddMoney(Benefits);
                            break;
                        case 2:
                            break;
                    }
                    break;
                }
            }
            
        }
        
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        UI.FullDraw(headers, page);
    }

    private void SelectJobCenter(Human entity, string[] headers, int page, Display UI)
    {
        int selectedItem = 0;
        DrawTable("JOB CENTERS");
        
        while (true) {}
    }
}

public class JobCenter(Job[] avaliableJobs, string name) : Box
{
    private Job[] AvaliableJobs = avaliableJobs;
    private string CenterName = name;

    

    public void DrawCenter(Human entity, string[] headers, int page, Display UI)
    {
        DrawBox();
        
        int Item = 0;
        int ItemsTop = AvaliableJobs.Length;
        
        int Page = 0;
        int MaxPages = AvaliableJobs.Length / 10;
        
        Console.SetCursorPosition(57, 3);
        Console.Write("{0, 15}", CenterName);
        Console.Clear();
        
        while (true) {
            
            int pos = 6;
            
            for (int i = Page * 10; i <= Page * 10 + 10; i++, pos++)
            {
                if (i == Item)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(26, pos);
                    Console.Write("{0,-55}", AvaliableJobs[i].PrintData());

                }
                else if (i >= ItemsTop)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(26, pos);
                    Console.Write(new string(' ', 55));
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(26, pos);
                    Console.Write("{0,-55}", AvaliableJobs[i].PrintData());
                }

            }

            Console.SetCursorPosition(0, 0);

            var Key = Console.ReadKey(true);

            if (Key.Key == ConsoleKey.DownArrow && Item < 10 && Item < ItemsTop - 1)
            {
                Item++;
            }
            else if (Key.Key == ConsoleKey.UpArrow && Item > 0)
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
                entity.Setjob(AvaliableJobs[Item]);
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


public class Job
{
    private string Name {get; set;}
    private string Description {get; set;}
    private (int Start, int Finish) Hours {get; set;}
    private int Salary {get; set;}

    public Job(string name, string description, int start, int finish, int salary)
    {
        Name = name;
        Description = description;
        Hours = (Start: start, Finish: finish);
        Salary = salary;
    }

    public void PaySalary(Human entity)
    {
        entity.AddMoney(Salary);
    }

    public string PrintData()
    {
        return $"{Name}, {Description} || Hours: {Hours.Start}:00 - {Hours.Finish}:00 || Salary: {Salary}";
    }
}