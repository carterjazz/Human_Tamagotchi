namespace Human_Tamagotchi.Objects;

public class Human
{
   private readonly Random _rng = new Random();
   
   private string Name { get; set; }
   private string HairColour { get; set; }
   private string EyeColour { get; set; }
   
   private int Age { get; set; }
   private int Money { get; set; }
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

      if (_rng.Next(0, 60) == 1)
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
   }

   public void DrawStats()
   {
      Console.Clear();
      Console.WriteLine("-----------------  STATS  -------------------");
      Console.WriteLine($"Name: {Name}");
      Console.WriteLine($"Age: {Age}");
      Console.WriteLine(Health.GetMentalState());
      if (Age >= 16)
      {
         Console.WriteLine(Sexuality.GetSexualAttraction());
         Console.WriteLine(Sexuality.GetRomanticAttraction());
      }

      Console.WriteLine(Gender.GetGenderIdentity());
     

   }

   public Health GetHealth()
   {
      return Health;
   }
   public void DrawHealth()
   {
      Console.Clear();
      Health.Draw(Name);
   }
   
   

   public void SetAgeTestTool(int age)
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

   public void DrawInventory()
   {
      Console.Clear();
      Inventory.Draw();
   }

}





