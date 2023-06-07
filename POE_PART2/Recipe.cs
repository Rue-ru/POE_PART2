using POE_PART2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POE_PART2
{
    class Recipe
    {

        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Description { get; set; }


        public Recipe(string recipeName)
        {
            RecipeName = recipeName;
            Ingredients = new List<Ingredient>();
            Description = new List<string>();
        }
        public void AddingIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddingStep(string description)
        {
            Description.Add(description);
        }

        public void DisplayingRecipe()
        {
            Console.WriteLine($"Recipe: {RecipeName}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.RecipeUnitofMeasure}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Description.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Description[i]}");
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

    }
}
