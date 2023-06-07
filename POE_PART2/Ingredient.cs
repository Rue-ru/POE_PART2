using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART2
{
    class Ingredient
    {
        public string IngredientName { get; set; }
        public double Quantity { get; set; }
        public string RecipeUnitofMeasure { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string ingredientName, double quantity, string recipeUnitofMeasure, int calories, string foodGroup)
        {
            IngredientName = ingredientName;
            Quantity = quantity;
            RecipeUnitofMeasure = recipeUnitofMeasure;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
