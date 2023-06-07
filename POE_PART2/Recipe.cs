using POE_PART2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART2
{
    public class Recipe
    {

        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Description { get; set; }
        public int Quantity { get; set; }
        public int RecipeUnitsofMeasure { get; set; }
        public int RecipeSteps { get; set; }


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

        public void AddingStep(string recipeSteps)
        {
            RecipeSteps.Add(recipeSteps);
        }

    }
}
