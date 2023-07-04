using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataReciepe
{
    public partial class MainWindow : Window
    {
        private readonly ReciepeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new ReciepeManager();
            PopulateRecipeListView();
        }

        private void PopulateRecipeListView()
        {
            recipeListView.ItemsSource = recipeManager.Reciepes;
        }

        private void FilterByIngredient_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = ingredientTextBox.Text;
            List<Reciepe> filteredRecipes = recipeManager.FilterReciepesByIngredient(ingredientName);
            recipeListView.ItemsSource = filteredRecipes;
        }

        private void FilterByFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            string? foodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            List<Reciepe> filteredRecipes = recipeManager.FilterRecipesByFoodGroup(foodGroup);
            recipeListView.ItemsSource = filteredRecipes;
        }

        private void FilterByMaxCalories_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(maxCaloriesTextBox.Text, out int maxCalories))
            {
                List<Reciepe> filteredRecipes = recipeManager.FilterRecipesByMaximumCalories(maxCalories);
                recipeListView.ItemsSource = filteredRecipes;
            }
            else
            {
                MessageBox.Show("Please enter a valid number for maximum calories.");
            }
        }
    }

    class Reciepe
    {
        public object Ingredients { get; internal set; }

        internal static object Where(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
