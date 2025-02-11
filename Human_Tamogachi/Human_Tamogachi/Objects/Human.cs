namespace Human_Tamagotchi.Objects;

public class Human
{
   private readonly Random _rng = new Random();
   
   private string Name { get; set; }
   private string HairColour { get; set; }
   private string EyeColour { get; set; }
   
   private int Age { get; set; }
   private float Money { get; set; }
   private int Radicalisation { get; set; }
   
   private int GenderMtFScale { get; set; }
   private int GenderBinaryScale { get; set; }
   
   private string Sex { get; set; }

   private bool isLGBT;
   private bool HasLunchBox;

   private Health Health { get; set; }
   private Gender Gender { get; set; }
   private Sexuality Sexuality { get; set; }
   private Inventory Inventory { get; set; }
   private Time Time { get; set; }

   public Human(string name)
   {
      Name = name;
      HairColour = "";
      EyeColour = "";

      Age = 0;
      Money = 0;
      Radicalisation = _rng.Next(0, 10) * 10;
      GenderMtFScale = _rng.Next(0, 10) * 10;
      GenderBinaryScale = _rng.Next(0, 10) * 10;
      HasLunchBox = false;

      if (_rng.Next(0, 20) == 1)
      {
         isLGBT = true;
      }
      else
      {
         isLGBT = false;
      }

      if (_rng.Next(0, 100) > 50)
      {
         Sex = "Female";
      }
      else
      {
         Sex = "Male";
      }
      
      Health = new Health();
      Gender = new Gender(Sex, GenderBinaryScale , GenderMtFScale, isLGBT);
      Sexuality = new Sexuality(GenderMtFScale, isLGBT);
      Inventory = new Inventory();
      Time = new Time(this);
      
   }

   public void Draw(int pad)
   {  
      Console.WriteLine();
      Console.WriteLine("||" + new string(' ', pad) + $"Name : {Name}");
      Console.WriteLine("||" + new string(' ',pad) + $"Age : {Age}");
      
      if (Money == (int) Money)
      {
         Console.WriteLine("||" + new string(' ', pad) + $"Balance : {Money}");
      }
      else
      { 
         Console.WriteLine("||" + new string(' ', pad) + $"Balance : {MathF.Round(Money, 1)}0");
      }

      Console.WriteLine("||" + new string(' ', pad) + Health.GetMentalState());
      

      if (Age >= 16)
      {
         Console.WriteLine("||" + new string(' ', pad) + "Sexuality: " + Sexuality.GetSexualAttraction() + new string(' ', 12));
         Console.WriteLine("||" + new string(' ', pad) + "Romance: " + Sexuality.GetRomanticAttraction() + new string(' ', 12));
      }
      Console.WriteLine("||" + new string(' ', pad)+ Gender.GetGenderIdentity() + new string(' ', 12));
      Console.WriteLine("||" + new string(' ', pad) + "Birthday: " + Time.GetInitalDate() + new string(' ', 12));
      Console.WriteLine("||" + new string(' ', pad) + "Current Date: " + Time.GetCurrentDate() + new string(' ', 12));

    

   }

   public Health GetHealth()
   {
      return Health;
   }
   public void DrawHealth(int pad, int startPos)
   {
      Health.Draw(pad, startPos);
   }
   
   

   public void SetAge(int age)
   {
      Age = age;
   }

   public bool IsLGBTGet()
   {
      return isLGBT;
   }

   public void AddFood(Food food)
   {
      Inventory.StoreFood(food, HasLunchBox);
   }

   public void setLunchBox(bool hasLunchBox)
   {
      HasLunchBox = hasLunchBox;
   }

   public void DrawInventory(int pad, int startPos, int page)
   {
      Inventory.Draw(pad, startPos, page);
   }

   public void EatFood(string[] headers, int page, Display UI)
   {
      Inventory.EatFood(this.GetHealth(), headers, page, UI);
   }

   public void AddMoney(float amount)
   {
      Money += amount;
      Money = (float) Math.Round(Money, 1);
   }

   public float GetMoney()
   {
      return Money;
   }

   public void IncreaseDay()
   { 
      Time.Increment();
   }

   public void IncreaseDay(int days)
   {
      for (int i = 0; i <= days; i++)
      {
         IncreaseDay();
      }
   }

   public void IncreaseYear()
   {
      IncreaseDay(Time.DOBAfterLeapDay() ? Time.isNextLeapYear() ? 365 : 364 : Time.isLeapYear() ? 365 : 364);
   }

   public void IncrementAge()
   {
      Age++;
   }

}





