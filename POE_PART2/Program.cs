using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace POE_PART2
{

    public class Program
    {
        public static int recipeSteps;
        public static int noOfRecipes;
        public static String recipeName;
        public static int noOfIngredients;
        public static String ingredientName;
        public static double quantity;
        public static String recipeUnitsofMeasure;
        public static int calories;
        public static String foodGroup;
        public static String description;

        static List<Recipe> recipesList = new List<Recipe>();

        static void Main(string[] args)
        {
            Console.WriteLine("Recipes Menu:");

            while (true) //while statement is true it will keep looping through this menu. 
            {
                Console.WriteLine("Please select from the options provided:");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. View Recipes");
                Console.WriteLine("3. Adjust Data");
                Console.WriteLine("4. Exit");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        Recipes();
                        break;
                    case "2":
                        Display();
                        break;
                    case "3":
                        Adjust();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select options between 1-4.");
                        break;
                }
            }
        }
        static void Recipes()
        {
            //adding recipe name, ingredients, units, quantities, calories, food group and steps
            Console.WriteLine("Recipe Name:");
            recipeName = Console.ReadLine();

            Recipe addRecipe = new Recipe(recipeName); //adding a list called addRecipe

            Console.WriteLine("Number of ingredients?");
            noOfIngredients = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < noOfIngredients; i++)
            {
                Console.WriteLine("Ingredient name:");
                //enter the ingredients you want 
                ingredientName = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Ingredient quantity:");
                quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Measuring units to use:");
                Console.WriteLine("Tsp, Tbsp, Gram, Kilogram, Cup, Millilitre, Litre, Quart, Pint,");
                Console.WriteLine(" Fl oz, Ounce, Gal, Pound, Slices, Diced, Large, Small ");
                Console.WriteLine();

                Console.WriteLine("Guidance of measuring units have been provided for you. \n Select a unit based on list provided:");
                recipeUnitsofMeasure = Console.ReadLine();

                Console.WriteLine("Ingredient calories:");
                calories = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Food Group the ingredient classifies as:");
                foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, quantity, recipeUnitsofMeasure, calories, foodGroup);
                addRecipe.AddingIngredient(ingredient);

                Console.WriteLine("Number of steps?");
                recipeSteps = Convert.ToInt32(Console.ReadLine());

                for (int b = 0; b < recipeSteps; b++)
                {
                    Console.WriteLine($"Step {b + 1}:");
                    description = Console.ReadLine();
                    addRecipe.AddingStep(description);
                }

                recipesList.Add(addRecipe);

                Console.WriteLine("Your recipe has successfully been added");
            }
        }
        static void Display()
        {
            //giving users the option to display the recipes or clear them. 
            int option;
            Console.WriteLine("Would you like display the entire recipe or clear the entire recipe out?");
            Console.WriteLine("1 --> Display");
            Console.WriteLine("2 --> Clear recipe");
            option = Convert.ToInt32(Console.ReadLine());

            while (option == 1 && option ==2) //exception handling function
            {
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("Recipe");
                    recipesList.Sort((res1, res2) => string.Compare(res1.RecipeName, res2.RecipeName)); //display the recipes tha have been added
                    for (int i = 0; i < recipesList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipesList[i].RecipeName}");
                    }

                    Console.Write("Enter the recipe number to view: ");
                    int recipeNumber = int.Parse(Console.ReadLine());

                    if (recipeNumber > 0 && recipeNumber <= recipesList.Count) //displaying the recipe they chose.
                    {
                        Recipe recipe = recipesList[recipeNumber - 1];
                        recipe.DisplayingRecipe();
                        double totalCalories = recipe.CalculateTotalCalories();
                        Console.WriteLine($"Total Calories: {totalCalories}");

                        if (totalCalories > 300)
                        {
                            Console.WriteLine("Warning: Total calories exceeds 300!");
                        }
                    }

                    Console.WriteLine("\n METHOD");
                    for (int b = 0; b < recipeSteps; b++)
                    {

                        Console.WriteLine("Step {0}", b);
                        Console.WriteLine(description);
                    }
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select options from the list provided");
                }
            
            }
        }

        static void Adjust()
        {
            //users can agjust their units of measurement
            int option2;
            Console.WriteLine("Would you like half, double or triple the recipe incredients ");
            Console.WriteLine("1 --> half");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> triple");
            Console.WriteLine("4 --> done");
            option2 = Convert.ToInt32(Console.ReadLine());

            switch (option2)
            {
                case 1:
                    Console.WriteLine("Recipe");
                    recipesList.Sort((res1, res2) => string.Compare(res1.RecipeName, res2.RecipeName));
                    for (int i = 0; i < recipesList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipesList[i].RecipeName}");
                    }

                    Console.Write("Enter the recipe number to view: ");
                    int recipeNumber = int.Parse(Console.ReadLine());

                    if (recipeNumber > 0 && recipeNumber <= recipesList.Count)
                    {
                        quantity = quantity / 0.5;
                        for (int b = 0; b < recipeSteps; b++)
                        {
                            Console.WriteLine("INGREDIENTS");
                            Console.WriteLine(ingredientName, quantity, recipeUnitsofMeasure);
                            Console.WriteLine("METHOD"); 
                            Console.WriteLine($"Step {b + 1}");
                            Console.WriteLine(description);
                        }
                    }

                    break;

                case 2:
                    Console.WriteLine("Recipe");
                    recipesList.Sort((res1, res2) => string.Compare(res1.RecipeName, res2.RecipeName));
                    for (int i = 0; i < recipesList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipesList[i].RecipeName}");
                    }

                    Console.Write("Enter the recipe number to view: ");
                    int recipeNumber2 = int.Parse(Console.ReadLine());

                    if (recipeNumber2 > 0 && recipeNumber2 <= recipesList.Count)
                    {
                        quantity = quantity *2;
                        for (int b = 0; b < recipeSteps; b++)
                        {
                            Console.WriteLine("INGREDIENTS");
                            Console.WriteLine(ingredientName, quantity, recipeUnitsofMeasure);
                            Console.WriteLine("METHOD");
                            Console.WriteLine($"Step {b + 1}");
                            Console.WriteLine(description);
                        }
                    }

                    break;

                case 3:
                    Console.WriteLine("Recipe");
                    recipesList.Sort((res1, res2) => string.Compare(res1.RecipeName, res2.RecipeName));
                    for (int i = 0; i < recipesList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {recipesList[i].RecipeName}");
                    }

                    Console.Write("Enter the recipe number to view: ");
                    int recipeNumber3 = int.Parse(Console.ReadLine());

                    if (recipeNumber3 > 0 && recipeNumber3 <= recipesList.Count)
                    {
                        quantity = quantity * 3;
                        for (int b = 0; b < recipeSteps; b++)
                        {
                            Console.WriteLine("INGREDIENTS");
                            Console.WriteLine(ingredientName, quantity, recipeUnitsofMeasure);
                            Console.WriteLine("METHOD");
                            Console.WriteLine($"Step {b + 1}");
                            Console.WriteLine(description);
                        }
                    }
                    break;

                case 4:
                    Environment.Exit(0);

                    break;

                default:
                    Console.WriteLine("Invalid option. Please select from menu provided");
                    Console.WriteLine("Would you like half, double or triple the recipe incredients ");
                    Console.WriteLine("1 --> half");
                    Console.WriteLine("2 --> double");
                    Console.WriteLine("3 --> triple");
                    Console.WriteLine("4 --> done");
                    option2 = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }


    }
}