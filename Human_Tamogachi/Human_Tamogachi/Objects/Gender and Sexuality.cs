namespace Human_Tamagotchi.Objects;

public class Gender
{
   private bool LGBT;
   private string Sex { get; set; }
   private int GenderValueX { get; set; }
   private int GenderValueY { get; set; }

   public Gender(string sex, int genderValueX, int genderValueY, bool lgbt)
   {
      Sex = sex;
      GenderValueX = genderValueX;
      GenderValueY = genderValueY;
      
      LGBT = lgbt;
   } 
     
      
   public string GetGenderIdentity()
   {
      if (LGBT)
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
                  return "Gender: Trans (MtF)";
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
                  return "Gender: Trans (FtM)";
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
      else
      {
         if (Sex == "Male")
         {
            return "Gender: Cis-Male";
         }
         else
         {
            return "Gender: Cis-Female";
         } 
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
   
   private bool LGBT;

   public Sexuality(int gender, bool lgbt)
   {
      LGBT = lgbt;
      Gender = gender;
      Lust = _rng.Next(0, 10) * 10;
      Love = _rng.Next(0, 10) * 10;;
      LustySwing = _rng.Next(0, 10) * 10;;
      LoveSwing = _rng.Next(0, 10) * 10;
   }

   public string GetSexualAttraction()
   {
      if (LGBT == false)
      {
         return $"Straight";
      }
      
      switch (Gender)
      {
         case >= 70:
            if (Lust >= 70 && LustySwing >= 70)
            {
               return $"Horny Lesbian ({Lust}% Lust)";
            } 
            else if (Lust >= 40 && LustySwing >= 70)
            {
               return $"Lesbian ({Lust}% Lust)";
            }
            else if (Lust >= 70 && LustySwing <= 30)
            {
               return $"Horny Straight ({Lust}% Lust)";
            }
            else if (Lust >= 40 && LustySwing <= 30)
            {
               return $"Straight ({Lust}% Lust)";
            }
            else if (Lust >= 70)
            {
               return $"Horny Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 40)
            {
               return $"Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 20)
            { 
               return $"Grey-Asexual ({Lust}% Lust)";
            }
            else
            { 
               return $"Asexual ({Lust}% Lust)";
            }
         case <= 30:
            if (Lust >= 70 && LustySwing >= 70)
            {
               return $"Horny Straight ({Lust}% Lust)";
            } 
            else if (Lust >= 40 && LustySwing >= 70)
            {
               return $"Straight ({Lust}% Lust)";
            }
            else if (Lust >= 70 && LustySwing <= 30)
            {
               return $"Horny Gay ({Lust}% Lust)";
            }
            else if (Lust >= 40 && LustySwing <= 30)
            {
               return $"Gay ({Lust}% Lust)";
            }
            else if (Lust >= 70)
            {
               return $"Horny Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 40)
            {
               return $"Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 20)
            { 
               return $"Grey-Asexual ({Lust}% Lust)";
            }
            else
            { 
               return $"Asexual ({Lust}% Lust)";
            }
         
         default:
            if (Lust >= 70 && LustySwing >= 70)
            {
               return $"Horny (for The Ladies) ({Lust}% Lust)";
            } 
            else if (Lust >= 40 && LustySwing >= 70)
            {
               return $"The Ladies ({Lust}% Lust)";
            }
            else if (Lust >= 70 && LustySwing <= 30)
            {
               return $"Horny (The Gentlemen) ({Lust}% Lust)";
            }
            else if (Lust >= 40 && LustySwing <= 30)
            {
               return $"The Gentlemen ({Lust}% Lust)";
            }
            else if (Lust >= 70)
            {
               return $"Horny Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 40)
            {
               return $"Bisexual ({Lust}% Lust)";
            }
            else if (Lust >= 20)
            { 
               return $"Grey-Asexual ({Lust}% Lust)";
            }
            else
            { 
               return $"Asexual ({Lust}% Lust)";
            }
         
         
      }
   }

   public string GetRomanticAttraction()
   {
      if (LGBT == false)
      {
         return $"Opposite Gender";
      }
      
      switch (Love)
      {
         case >= 70:
            if (LoveSwing >= 70)
            {
               return $"Horny Women Enjoyer";
            }
            else if (LoveSwing <= 30)
            {
               return $"Horny BoyKisser";
            }
            else
            {
               return $"Anything That Moves (and can consent)";
            }
         case >= 40:
            if (LoveSwing >= 70)
            {
               return $"Women Enjoyer";
            }
            else if (LoveSwing <= 30)
            {
               return $"BoyKisser";
            }
            else
            {
               return $"All of the Above";
            }
         case >= 20:
            return $"Grey-romantic ";
         default:
            return "Aromantic";
      }
   }
   
}