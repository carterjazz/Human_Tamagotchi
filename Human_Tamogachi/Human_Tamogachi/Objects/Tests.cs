namespace Human_Tamagotchi.Objects;

public class Tests
{
    private int RANGE;
    private Human[] TestCases;

    public Tests(int range)
    {
        RANGE = range;
        TestCases = new Human[RANGE];
        
        for (int i = 0; i < RANGE; i++)
        {
            TestCases[i] = new Human("NULL");
            TestCases[i].SetAge(18);
        }
    }

    public int QueerCount()
    {
        int count = 0;
        
        for (int i = 0; i < RANGE; i++)
        {
            if (TestCases[i].IsLGBTGet())
            {
                count++;
                Console.WriteLine($"Index({i})");
            }
        }
        return count;
    }
}