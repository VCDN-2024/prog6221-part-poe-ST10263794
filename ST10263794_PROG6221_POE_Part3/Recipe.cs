using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10263794_PROG6221_POE_Part3
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Calculate total calories for the recipe
        public int TotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        // Scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
                ingredient.Calories = (int)(ingredient.Calories * factor);  // Adjust calories according to the scale factor
            }
        }
    }
}
