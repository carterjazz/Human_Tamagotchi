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
   
   private string Sex { get; set; }

   private Health Health { get; set; }
   private Gender Gender { get; set; }
   private Sexuality Sexuality { get; set; }

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
      Gender = new Gender(Sex, GenderBinaryScale , GenderMtFScale);
      Sexuality = new Sexuality(GenderMtFScale);
   }

   public void Draw()
   {
      Console.WriteLine($"----------------- {Name}  -------------------");
      Console.WriteLine("-----------------  STATS  -------------------");
      Console.WriteLine($"Name: {Name}");
      Console.WriteLine($"Age: {Age}");

      if (Age >= 16)
      {
         Console.WriteLine(Sexuality.GetSexualAttraction());
         Console.WriteLine(Sexuality.GetRomanticAttraction());
      }

      Console.WriteLine(Gender.GetGenderIdentity());
      Console.WriteLine("---------------------------------------------");

   }

   public void setAge(int age)
   {
      Age = age;
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
               return $"Gender: Non-Binary ({GenderValueX}% Binary)";
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
   

   public Sexuality(int gender)
   {
      Gender = gender;
      Lust = _rng.Next(0, 10) * 10;
      Love = _rng.Next(0, 10) * 10;;
      LustySwing = _rng.Next(0, 10) * 10;;
      LoveSwing = _rng.Next(0, 10) * 10;
   }

   public string GetSexualAttraction()
   {
      switch (Gender)
      {
         case >= 70:
            if (Lust >= 70 && LustySwing >= 70)
            {
               return $"Sexual Attraction: Horny Lesbian ({Lust}% Lust)";
            } 
            else if (Lust >= 40 && LustySwing >= 70)
            {
               return $"Sexual Attraction: Lesbian ({Lust}% Lust)";
            }
            else if (Lust >= 70 && LustySwing <= 30)
            {
               return $"Sexual Attraction: Horny Straight ({Lust}% Lust)";
            }
            else if (Lust >= 40 && LustySwing <= 30)
            {
               return $"Sexual Attraction: Straight ({Lust}% Lust)";
            }
            else if (Lust >= 70)
            {
               return $"Sexual Attraction: Horny Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 40)
            {
               return $"Sexual Attraction: Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 20)
            { 
               return $"Sexual Attraction: Grey-Asexual ({Lust}% Lust)";
            }
            else
            { 
               return $"Sexual Attraction: Asexual ({Lust}% Lust)";
            }
         case <= 30:
            if (Lust >= 70 && LustySwing >= 70)
            {
               return $"Sexual Attraction: Horny Straight ({Lust}% Lust)";
            } 
            else if (Lust >= 40 && LustySwing >= 70)
            {
               return $"Sexual Attraction: Straight ({Lust}% Lust)";
            }
            else if (Lust >= 70 && LustySwing <= 30)
            {
               return $"Sexual Attraction: Horny Gay ({Lust}% Lust)";
            }
            else if (Lust >= 40 && LustySwing <= 30)
            {
               return $"Sexual Attraction: Gay ({Lust}% Lust)";
            }
            else if (Lust >= 70)
            {
               return $"Sexual Attraction: Horny Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 40)
            {
               return $"Sexual Attraction: Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 20)
            { 
               return $"Sexual Attraction: Grey-Asexual ({Lust}% Lust)";
            }
            else
            { 
               return $"Sexual Attraction: Asexual ({Lust}% Lust)";
            }
         
         default:
            if (Lust >= 70 && LustySwing >= 70)
            {
               return $"Sexual Attraction: Horny (for The Ladies) ({Lust}% Lust)";
            } 
            else if (Lust >= 40 && LustySwing >= 70)
            {
               return $"Sexual Attraction: The Ladies ({Lust}% Lust)";
            }
            else if (Lust >= 70 && LustySwing <= 30)
            {
               return $"Sexual Attraction: Horny (The Gentlemen) ({Lust}% Lust)";
            }
            else if (Lust >= 40 && LustySwing <= 30)
            {
               return $"Sexual Attraction: The Gentlemen ({Lust}% Lust)";
            }
            else if (Lust >= 70)
            {
               return $"Sexual Attraction: Horny Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 40)
            {
               return $"Sexual Attraction: Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 20)
            { 
               return $"Sexual Attraction: Grey-Asexual ({Lust}% Lust)";
            }
            else
            { 
               return $"Sexual Attraction: Asexual ({Lust}% Lust)";
            }
         
         
      }
   }

   public string GetRomanticAttraction()
   {
      switch (Love)
      {
         case >= 70:
            if (LoveSwing >= 70)
            {
               return $"Romantic Attraction: Horny Women Enjoyer";
            }
            else if (LoveSwing <= 30)
            {
               return $"Romantic Attraction: Horny BoyKisser";
            }
            else
            {
               return $"Romantic Attraction: Anything That Moves (and can consent)";
            }
         case >= 40:
            if (LoveSwing >= 70)
            {
               return $"Romantic Attraction: Women Enjoyer";
            }
            else if (LoveSwing <= 30)
            {
               return $"Romantic Attraction: BoyKisser";
            }
            else
            {
               return $"Romantic Attraction: All of the Above";
            }
         case >= 20:
            return $"Romantic Attraction: Greyromantic ";
         default:
            return "Romantic Attraction: Aromantic";
      }
   }
   
}

