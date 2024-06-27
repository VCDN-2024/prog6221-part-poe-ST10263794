using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10263794_PROG6221_POE_Part3
{
    public partial class IngredientEntryWindow : Window
    {
        public Ingredients Ingredient { get; private set; }

        public IngredientEntryWindow()
        {
            InitializeComponent();
            IngredientFoodGroup.ItemsSource = FoodGroup.FoodGroups; // Populate food group options
        }

        // Event handler for saving the ingredient
        private void SaveIngredient_Click(object sender, RoutedEventArgs e)
        {
            double quantity = double.Parse(IngredientQuantity.Text);
            string unit = IngredientUnit.Text;

            // Convert quantity to standard unit (grams)
            if (unit == "Teaspoons")
                quantity *= 5;
            else if (unit == "Tablespoons")
                quantity *= 15;
            else if (unit == "Cups")
                quantity *= 240;

            Ingredient = new Ingredients
            {
                Name = IngredientName.Text,
                Quantity = quantity,
                Unit = "Grams", // Store all quantities in grams
                Calories = int.Parse(IngredientCalories.Text),
                FoodGroup = IngredientFoodGroup.SelectedItem.ToString()
            };
            DialogResult = true;
            Close();
        }
    }
}
