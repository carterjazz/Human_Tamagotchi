namespace Human_Tamagotchi.Objects;

public class Tests
{
    private const int RANGE = 1000;
    private Human[] TestCases = new Human[RANGE];

    public Tests()
    {
        for (int i = 0; i < RANGE; i++)
        {
            TestCases[i] = new Human("NULL");
            TestCases[i].SetAgeTestTool(18);
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