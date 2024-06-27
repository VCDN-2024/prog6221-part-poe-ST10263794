using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10263794_PROG6221_POE_Part3
{
    public class Ingredients
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Parse ingredient details from a string
        public static Ingredients Parse(string ingredientString)
        {
            // Example string: "2 Teaspoons of Sugar (32 calories, Vegetables and fruits)"
            var parts = ingredientString.Split(new[] { ' ' }, 4);
            var quantity = double.Parse(parts[0]);
            var unit = parts[1];
            var name = parts[3].Split('(')[0].Trim();
            var calories = int.Parse(parts[3].Split('(')[1].Split(' ')[0]);
            var foodGroup = parts[3].Split('(')[1].Split(',')[1].Trim().TrimEnd(')');

            // Convert quantity back to standard unit (grams)
            if (unit == "Teaspoons")
                quantity *= 5;
            else if (unit == "Tablespoons")
                quantity *= 15;
            else if (unit == "Cups")
                quantity *= 240;

            return new Ingredients
            {
                Name = name,
                Quantity = quantity,
                Unit = "Grams", // Store all quantities in grams
                Calories = calories,
                FoodGroup = foodGroup
            };
        }
    }
}

