using System.Globalization;

namespace Human_Tamagotchi;

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
   
   private int Swing { get; set; }
   private int Desire { get; set; }

   private string Sex { get; set; }

   private Health Health { get; set; }
   private Gender Gender { get; set; }

   public Human(string name, string hairColour, string eyeColour, string sex)
   {
      Name = name;
      HairColour = hairColour;
      EyeColour = eyeColour;

      Age = 0;
      Money = 0;
      Radicalisation = _rng.Next(0, 10) * 10;
      Sex = sex;
      GenderMtFScale = _rng.Next(0, 10) * 10;
      GenderBinaryScale = _rng.Next(0, 10) * 10;
      
      Health = new Health();
      Gender = new Gender(Sex, GenderMtFScale , GenderBinaryScale);
   }

   public void Draw()
   {
      Console.WriteLine($"Name: {Name}");
      Console.WriteLine($"Age: {Age}");
      Console.WriteLine();
      Console.WriteLine(Gender.GetGenderIdentity());

   }

}

public class Health
{
   private readonly Random _rng = new Random();

   private string MentalState { get; set; }

   private bool Addiction { get; set; }
   private bool Insanity { get; set; }

   private int HealthPoints { get; set; }
   private int Happiness { get; set; }
   private int Hunger { get; set; }

   public Health()
   {
      Addiction = false;
      Insanity = false;

      HealthPoints = 100;
      Happiness = _rng.Next(4, 10) * 10;
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
}

public class Gender
{
   private string Sex { get; set; }
   private int GenderValueX { get; set; }
   private int GenderValueY { get; set; }

   public Gender(string sex, int genderValueX, int genderValueY)
   {
      Sex = sex;
      GenderValueX = genderValueX;
      GenderValueY = genderValueY;
   } 
     
      
   public string GetGenderIdentity()
   {
      switch (Sex)
      {
         case "Male":
            if (GenderValueY <= 30)
            {
               return "Gender: Cis-Male";
            }
            else if (GenderValueY >= 70) 
            { 
               return "Gender: Trans-Femme";
            }
            else if (GenderValueY > 30 && GenderValueY < 70 && GenderValueX >= 50)
            {
               return $"Gender: Gender-Fluid ({GenderValueX}% Binary)";
            }
            else 
            {
               return $"Gender: Non-Binary ({GenderValueX}% Binary))";
            }
         case "Female":
            if (GenderValueY <= 30) 
            {
               return "Gender: Trans-Masc";
            }
            else if (GenderValueY >= 70)
            { 
               return "Gender: Cis-Female ";
            }
            else if (GenderValueY > 30 && GenderValueY < 70 && GenderValueX >= 50)
            {
               return $"Gender: Gender-Fluid ({GenderValueX}% Binary)";
            }
            else
            {
               return $"Gender: Non-Binary ({GenderValueX}% Binary))";
            }
         default:
            return "NULL";
            
      } 
   }
}

public class Sexuality
{
   private readonly Random _rng = new Random();
   
   private int Gender;
   private int Lust;
   private int Love;
   private int LustySwing;
   private int LoveSwing;
   

   public Sexuality(int gender, int desire, int swing)
   {
      Gender = gender;
      Lust = _rng.Next(0, 10) * 10;
      Love = _rng.Next(0, 10) * 10;;
      LustySwing = _rng.Next(0, 10) * 10;;
      LoveSwing = _rng.Next(0, 10) * 10;
   }

   public string GetSexualIdentity()
   {
      
   }

}

