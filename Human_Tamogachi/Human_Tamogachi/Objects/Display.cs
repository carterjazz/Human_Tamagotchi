namespace Human_Tamagotchi.Objects;

public class Display(Human entity)
{
    private Human Entity { get; set; } = entity;

    public void Draw()
    {
        Console.Clear();
        
    }
}