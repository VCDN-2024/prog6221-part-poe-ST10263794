using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class RecipeEntryWindow : Window
    {
        public Recipe Recipe { get; private set; }

        public RecipeEntryWindow()
        {
            InitializeComponent();
            IngredientList.ItemsSource = new List<string>();
            StepList.ItemsSource = new List<string>();
        }

        // Event handler for adding a new ingredient
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            IngredientEntryWindow ingredientWindow = new IngredientEntryWindow();
            if (ingredientWindow.ShowDialog() == true)
            {
                var ingredients = (List<string>)IngredientList.ItemsSource;
                ingredients.Add($"{ingredientWindow.Ingredient.Quantity} {ingredientWindow.Ingredient.Unit} of {ingredientWindow.Ingredient.Name} ({ingredientWindow.Ingredient.Calories} calories, {ingredientWindow.Ingredient.FoodGroup})");
                IngredientList.ItemsSource = null;
                IngredientList.ItemsSource = ingredients;
            }
        }

        // Event handler for adding a new step
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            StepEntryWindow stepWindow = new StepEntryWindow();
            if (stepWindow.ShowDialog() == true)
            {
                var steps = (List<string>)StepList.ItemsSource;
                steps.Add(stepWindow.Step);
                StepList.ItemsSource = null;
                StepList.ItemsSource = steps;
            }
        }

        // Event handler for saving the recipe
        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe = new Recipe
            {
                Name = RecipeName.Text,
                Ingredients = new List<Ingredients>(((List<string>)IngredientList.ItemsSource).ConvertAll(i => Ingredients.Parse(i))),
                Steps = new List<string>(((List<string>)StepList.ItemsSource))
            };
            DialogResult = true;
            Close();
        }
    }
}
