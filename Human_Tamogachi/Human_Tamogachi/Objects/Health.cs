namespace Human_Tamagotchi.Objects;

public class Health
{
   private readonly Random _rng = new Random();

   private string MentalState { get; set; }

   private bool Addiction { get; set; }
   private bool Insanity { get; set; }

   private int HealthPoints { get; set; }
   private int Happiness { get; set; }
   private int Hunger  { get; set; }
   private int MunchMeter { get; set; }
   public Health()
   {
      Addiction = false;
      Insanity = false;

      HealthPoints = 100;
      MunchMeter = 0;
      
      Happiness = _rng.Next(0, 10) * 10;
      Hunger = _rng.Next(5, 10) * 10;

      switch (Happiness)
      {
         case >= 90:
            MentalState = "Ecstatic";
            break;
         case >= 60:
            MentalState = "Content";
            break;
         default:
            MentalState = "Indifferent";
            break;
      }
   }
   
   public void Draw(int pad, int startPos)
   {
      Console.SetCursorPosition(startPos, 9);
      Console.Write(new string(' ', pad) + $"Health: {HealthPoints}");
      Console.SetCursorPosition(startPos, 10);
      Console.Write(new string(' ',pad) + $"Happiness : {Happiness}");
      Console.SetCursorPosition(startPos, 11);
      Console.Write(new string(' ', pad) + $"Hunger : {Hunger}");
      Console.SetCursorPosition(startPos, 12);
      Console.Write(new string(' ', pad) + $"Addiction : {Addiction}");
      Console.SetCursorPosition(startPos, 13);
      Console.Write(new string(' ', pad) + $"Insanity : {Insanity}");
      Console.SetCursorPosition(startPos, 14);
      
   }

   public string GetMentalState()
   {
      switch (Happiness)
      {
         case >= 90:
            return "Mental State: Ecstatic";
         case >= 60:
            return "Mental State: Content";
         case >= 40:
            return "Mental State: Indifferent";
         case >= 20:
            return "Mental State: Sad";
         default:
            return "Mental State: Les Miserables";
      }
   }

   public void Ate(int foodValue, string foodType)
   {
      if (Hunger + foodValue <= 100)
      {
         Hunger += foodValue;
      }
      else
      {
         Hunger = 100;
         MunchMeter++;
      }

      switch (foodType)
      {
         case "Fat":
            break;
         case "Carb":
            break;
         case "Dairy":
            break;
         case "FruitAndVeg":
            break;
         case "Protein":
            break;
         case "Sugar":
            break;
         default:
            break;
      }
   }

  

}