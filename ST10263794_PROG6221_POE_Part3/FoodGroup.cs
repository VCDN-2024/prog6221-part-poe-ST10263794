using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10263794_PROG6221_POE_Part3
{
    public static class FoodGroup
    {
        public static List<string> FoodGroups { get; } = new List<string>
        {
            "Starchy foods",
            "Vegetables and fruits",
            "Dry beans, peas, lentils and soya",
            "Chicken, fish, meat and eggs",
            "Milk and dairy products",
            "Fats and oil",
            "Water"
        };

        // Get the food group by index
        public static string GetFoodGroupByIndex(int index)
        {
            if (index >= 1 && index <= FoodGroups.Count)
            {
                return FoodGroups[index - 1];
            }
            return null;
        }

        // Display food groups for selection
        public static void DisplayFoodGroups()
        {
            for (int i = 0; i < FoodGroups.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {FoodGroups[i]}");
            }
        }
    }
}