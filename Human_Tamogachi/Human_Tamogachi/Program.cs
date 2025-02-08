// See https://aka.ms/new-console-template for more information

using Human_Tamagotchi;
using Human_Tamagotchi.Objects;

Human human01 = new Human("Adam");
human01.SetAgeTestTool(16);
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Chocolate", "Sugar", 3, 20));
human01.AddFood(new Food("Cherry", "FruitAndVeg", 50, 3));
human01.AddFood(new Food("Milk", "Dairy", 10, 1));
human01.AddFood(new Food("Pork Scratchings", "Fat", 1, 10));
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Bread", "Carb", 10, 15));
human01.AddFood(new Food("Bread", "Carb", 10, 15));


Display UI = new Display(human01);
UI.Draw();


