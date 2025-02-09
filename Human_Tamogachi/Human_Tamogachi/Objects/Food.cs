namespace Human_Tamagotchi.Objects;

public class Food(string name, string type, int amount, int foodValue)
{
    private int FoodValue = foodValue;
    private int Amount = amount;
    private string Type = type;
    public readonly string Name = name;

    public int Eat(Health health)
    {
        if (Amount >= 1)
        { 
            health.Ate(FoodValue, Type);
            Amount--;
            return Amount;
        }
        else
        { 
            return 0;
        }
        
    }

    public int ReturnAmount()
    {
        return Amount;
    }
    public string Display()
    {
        return $"{Name} (Amt: {Amount}, Val: {FoodValue}, Typ: {Type})";
    }
}