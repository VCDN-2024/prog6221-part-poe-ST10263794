using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10263794_PROG6221_POE_Part3
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            FoodGroupFilter.ItemsSource = FoodGroup.FoodGroups; // Populate food group filter options
        }

        // Event handler for adding a new recipe
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeEntryWindow entryWindow = new RecipeEntryWindow();
            if (entryWindow.ShowDialog() == true)
            {
                recipes.Add(entryWindow.Recipe);
                UpdateRecipeList(); // Refresh the recipe list after adding a new recipe
            }
        }

        // Update the ListView with the current list of recipes
        private void UpdateRecipeList()
        {
            RecipeListView.ItemsSource = recipes.OrderBy(r => r.Name).Select(r => new
            {
                r.Name,
                TotalCalories = r.TotalCalories(),
                IngredientCount = r.Ingredients.Count
            }).ToList();
        }

        // Event handler for filtering recipes based on user input
        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientFilter.Text.ToLower();
            string foodGroup = FoodGroupFilter.SelectedItem?.ToString();
            int maxCalories = int.TryParse(MaxCaloriesFilter.Text, out int result) ? result : int.MaxValue;

            var filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup == foodGroup)) &&
                r.TotalCalories() <= maxCalories
            ).OrderBy(r => r.Name).ToList();

            RecipeListView.ItemsSource = filteredRecipes.Select(r => new
            {
                r.Name,
                TotalCalories = r.TotalCalories(),
                IngredientCount = r.Ingredients.Count
            }).ToList();
        }

        // Event handler for displaying recipe details when a recipe is selected
        private void RecipeListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipeListView.SelectedIndex >= 0)
            {
                var selectedRecipe = recipes[RecipeListView.SelectedIndex];
                RecipeName.Text = selectedRecipe.Name;
                int totalCalories = selectedRecipe.TotalCalories();

                // Display the calorie warning if calories exceed 300
                if (totalCalories > 300)
                {
                    CalorieWarning.Text = "Warning: This recipe exceeds 300 calories!";
                }
                else
                {
                    CalorieWarning.Text = "";
                }

                // Display total calories with explanations for certain ranges
                if (totalCalories <= 100)
                {
                    CalorieWarning.Text += " (Low calorie)";
                }
                else if (totalCalories <= 200)
                {
                    CalorieWarning.Text += " (Moderate calorie)";
                }
                else
                {
                    CalorieWarning.Text += " (High calorie)";
                }

                IngredientList.ItemsSource = selectedRecipe.Ingredients.Select(i => $"{i.Quantity} {i.Unit} of {i.Name} ({i.Calories} calories, {i.FoodGroup})").ToList();
                StepList.ItemsSource = selectedRecipe.Steps.Select((s, index) => new { StepNumber = index + 1, Description = s }).ToList();
            }
        }
    }
}