using DataReciepe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataReciepe
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Ingredient ingredient = new()
            {
                Name = name,
                Quantity = quantity,
                Unit = unit,
                Calories = calories,
                FoodGroup = foodGroup
            };

            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");

            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories)");
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;

            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            return totalCalories;
        }
    }

    class Program
    {
        delegate void RecipeExceedsCaloriesHandler(string recipeName, int totalCalories);

        static void Main(string[] args)
        {
            List<Recipe> recipes = new();
            RecipeExceedsCaloriesHandler caloriesHandler = NotifyRecipeExceedsCalories;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. View recipes");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Recipe recipe = CreateRecipe(caloriesHandler);
                        recipes.Add(recipe);
                        break;
                    case "2":
                        ViewRecipes(recipes);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static Recipe CreateRecipe(RecipeExceedsCaloriesHandler caloriesHandler)
        {
            Recipe recipe = new();

            Console.WriteLine("Enter recipe details:");

            Console.Write("Recipe name: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Ingredient {i + 1} name: ");
                string ingredientName = Console.ReadLine();

                Console.Write($"Ingredient {i + 1} quantity: ");
                double ingredientQuantity = double.Parse(Console.ReadLine());

                Console.Write($"Ingredient {i + 1} unit: ");
                string ingredientUnit = Console.ReadLine();

                Console.Write($"Ingredient {i + 1} calories: ");
                int ingredientCalories = int.Parse(Console.ReadLine());

                Console.Write($"Ingredient {i + 1} food group: ");
                string ingredientFoodGroup = Console.ReadLine();

                recipe.AddIngredient(ingredientName, ingredientQuantity, ingredientUnit, ingredientCalories, ingredientFoodGroup);
            }

            Console.Write("Number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string step = Console.ReadLine();

                recipe.AddStep(step);
            }

            int totalCalories = recipe.CalculateTotalCalories();
            if (totalCalories > 300)
            {
                caloriesHandler?.Invoke(recipe.Name, totalCalories);
            }

            return recipe;
        }

        static void ViewRecipes(List<Recipe> recipes)
        {
            Console.WriteLine("Recipes:");

            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));

                foreach (var recipe in recipes)
                {
                    Console.WriteLine(recipe.Name);
                }

                Console.Write("Enter the name of the recipe to display: ");
                string recipeName = Console.ReadLine();

                Recipe selectedRecipe = recipes.Find(r => r.Name == recipeName);
                if (selectedRecipe != null)
                {
                    Console.WriteLine();
                    selectedRecipe.DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
            }
        }

        static void NotifyRecipeExceedsCalories(string recipeName, int totalCalories)
        {
            Console.WriteLine($"Warning: The recipe '{recipeName}' exceeds 300 calories. Total calories: {totalCalories}");




        public class RecipeManager
        {
            private readonly List<Recipe> recipes;

            public RecipeManager()
            {
                recipes = new List<Recipe>();
            }

            // Other methods for managing recipes

            public List<Recipe> FilterReciepeByIngredient(string ingredientName)
            {
                return recipes.Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            public List<Recipe> FilterReciepeByFoodGroup(string foodGroup)
            {
                return recipes.Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            public List<Recipe> FilterReciepeByMaximumCalories(int maxCalories)
            {
                return recipes.Where(recipe => recipe.CalculateTotalCalories() <= maxCalories).ToList();
            }
        }
    }
}
