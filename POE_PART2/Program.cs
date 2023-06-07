﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

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
            while (true)
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
        public static void Recipes()
        {
            Console.WriteLine("Recipe Name:");
            recipeName = Console.ReadLine();

            Recipe addRecipe = new Recipe(recipeName);

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

                //    Console.WriteLine("Return to MAIN MENU or EXIT SYSTEM");
                //    Console.WriteLine("1. Main Menu");
                //    Console.WriteLine("2. Exit");
                //    int menu = Convert.ToInt32(Console.ReadLine());

                //switch(menu)
                //{
                //    case 1:
                //        Main();
                //        break;

                //    case 2:
                //        Environment.Exit(0);
                //        break;

                //    default:
                //        Console.WriteLine("Please select an option 1 0r 2.");
                //        Console.WriteLine("(1) Return to MAIN MENU or (2) EXIT SYSTEM");
                //        Console.WriteLine("1. Main Menu");
                //        Console.WriteLine("2. Exit");
                //        break; 
                // }
            }
        }
        public static void Display()
        {
            int option;
            Console.WriteLine("Would you like display the entire recipe or clear the entire recipe out?");
            Console.WriteLine("1 --> Display");
            Console.WriteLine("2 --> Clear recipe");
            option = Convert.ToInt32(Console.ReadLine());

            if (option == 0)
            {
                Console.WriteLine("Invalid option");
                return;
            }
            if (option == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("INGREDIENTS");
                for (int i = 0; i < noOfIngredients; i++)
                {
                    Console.WriteLine(ingredientName + " " + quantity + " " + recipeUnitsofMeasure);
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
            else if (option == 2)
            {
                Array.Clear(ingredientName, 0, ingredientName.Length);
                Array.Clear(quantity, 0, quantity.Length);
                Array.Clear(recipeUnitsofMeasure, 0, recipeUnitsofMeasure.Length);
                Array.Clear(description, 0, description.Length);
                return;
            }
        }

        public static void Adjust()
        {
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
                    for (int i = 0; i < noOfIngredients; i++)
                    {
                        Console.WriteLine(ingredientName + " " + quantity / 0.5 + " " + recipeUnitsofMeasure);

                    }

                    for (int b = 0; b < recipeSteps; b++)
                    {
                        Console.WriteLine("INGREDIENTS");
                        Console.WriteLine($"Step {b + 1}");
                        Console.WriteLine("\n METHOD");
                        Console.WriteLine(description);
                    }
                    break;

                case 2:
                    for (int i = 0; i < noOfIngredients; i++)
                    {
                        Console.WriteLine(ingredientName + " " + quantity * 2 + " " + recipeUnitsofMeasure);
                    }

                    for (int b = 0; b < recipeSteps; b++)
                    {
                        Console.WriteLine("INGREDIENTS");
                        Console.WriteLine($"Step {b + 1}");
                        Console.WriteLine("\n METHOD");
                        Console.WriteLine(description);
                    }
                    break;

                case 3:
                    for (int i = 0; i < noOfIngredients; i++)
                    {
                        Console.WriteLine(ingredientName + " " + quantity * 3 + " " + recipeUnitsofMeasure);
                    }

                    for (int b = 0; b < recipeSteps; b++)
                    {
                        Console.WriteLine("INGREDIENTS");
                        Console.WriteLine($"Step {b + 1}");
                        Console.WriteLine("\n METHOD");
                        Console.WriteLine(description);
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