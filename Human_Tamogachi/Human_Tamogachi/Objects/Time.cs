namespace Human_Tamagotchi.Objects;

public class Time
{
    private static readonly int[] DAYSINMONTHS = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    private static (int Day, int Month, int Year) InitalDate { get; set; }
    private int[] CurrentDate = new int[3];
    private Human Entity { get; set; }

    public Time(Human entity)
    {
         InitalDate = (Day: DateTime.Now.Day, Month: DateTime.Now.Month, Year: DateTime.Now.Year);
         
         CurrentDate[0] = InitalDate.Day;
         CurrentDate[1] = InitalDate.Month;
         CurrentDate[2] = InitalDate.Year;

         Entity = entity;
    }

    public Time(Human entity, int day, int month, int year)
    {
        InitalDate = (day, month, year);
        
        CurrentDate[0] = InitalDate.Day;
        CurrentDate[1] = InitalDate.Month;
        CurrentDate[2] = InitalDate.Year;
        
        Entity = entity;
    }

    public void Increment()
    {

        if (isLeapYear())
        {
            if (CurrentDate[1] == 12 && CurrentDate[0] + 1 > 31)
            {
                IncrementYear();
            }
            else if (CurrentDate[1] == 2 && CurrentDate[0] + 1 > 29)
            {
                IncrementMonth();
            }
            else if (CurrentDate[0] + 1 > DAYSINMONTHS[CurrentDate[1] - 1] && CurrentDate[1] != 2)
            {
                IncrementMonth();
            }
            else
            {
                CurrentDate[0]++;
            }
            
        }

        else
        {
            
            if (CurrentDate[1] == 12 && CurrentDate[0] + 1 > 31)
            {
                IncrementYear();
            }
            else if (CurrentDate[0] + 1 > DAYSINMONTHS[CurrentDate[1] - 1])
            {
                IncrementMonth();
            }
            else
            {
                CurrentDate[0]++;
            }
            
        }
        
        if (CurrentDate[0] == InitalDate.Day && CurrentDate[1] == InitalDate.Month && CurrentDate[2] != InitalDate.Year)
        {
            Age();
        }

    }

    public string GetInitalDate()
    {
        return InitalDate.Day + "/" + InitalDate.Month + "/" + InitalDate.Year;
    }

    public string GetCurrentDate()
    {
        return CurrentDate[0] + "/" + CurrentDate[1] + "/" + CurrentDate[2];
    }

    public bool isLeapYear()
    {
        return CurrentDate[2] % 4 == 0;
    }

    public bool isNextLeapYear()
    {
        return (CurrentDate[2] + 1) % 4 == 0;
    }

    public bool DOBAfterLeapDay()
    {
        return InitalDate.Month > 2;
    }

    private void IncrementMonth()
    {
        CurrentDate[1]++;
        CurrentDate[0] = 1;
    }

    private void IncrementYear()
    {
        CurrentDate[2]++;
        CurrentDate[1] = 1;
        CurrentDate[0] = 1;
    }

    private void Age()
    { 
        Entity.IncrementAge();
    }
}