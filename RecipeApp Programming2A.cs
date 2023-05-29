using System;
using System.Collections.Generic;

class Ingredient
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }
}

class Recipe
{
    private List<Ingredient> ingredients;
    private string[] steps;

    public Recipe()
    {
        ingredients = new List<Ingredient>();
    }

    public void EnterRecipe()
    {
        Console.WriteLine("Enter the number of ingredients:");
        int numIngredients = int.Parse(Console.ReadLine());

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter the name of ingredient {i + 1}:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter the quantity of ingredient {i + 1}:");
            string quantity = Console.ReadLine();

            Console.WriteLine($"Enter the unit of measurement for ingredient {i + 1}:");
            string unit = Console.ReadLine();

            Console.WriteLine($"Enter the number of calories for ingredient {i + 1}:");
            int calories = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the food group for ingredient {i + 1}:");
            string foodGroup = Console.ReadLine();

            Ingredient ingredient = new Ingredient
            {
                Name = name,
                Calories = calories,
                FoodGroup = foodGroup
            };

            ingredients.Add(ingredient);
        }

        Console.WriteLine("Enter the number of steps:");
        int numSteps = int.Parse(Console.ReadLine());
        steps = new string[numSteps];

        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            steps[i] = Console.ReadLine();
        }
    }

    public void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe:");

        Console.WriteLine("\nIngredients:");
        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    public int CalculateTotalCalories()
    {
        int totalCalories = 0;
        foreach (Ingredient ingredient in ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }

    public delegate void CalorieNotificationDelegate(Recipe recipe, int totalCalories);

    public void NotifyCalorieExceedsLimit(int limit, CalorieNotificationDelegate calorieNotification)
    {
        int totalCalories = CalculateTotalCalories();
        if (totalCalories > limit)
        {
            calorieNotification(this, totalCalories);
        }
    }

    public void ScaleRecipe(double scaleFactor)
    {
        foreach (Ingredient ingredient in ingredients)
        {
            ingredient.Calories = (int)(ingredient.Calories * scaleFactor);
        }
    }

    public void ResetQuantities()
    {
        // Revert ingredient quantities to their original values
        // (assuming original values are stored elsewhere)
    }
    public void ClearRecipe()
    {
        ingredients.Clear();
        steps = null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display the recipe");
            Console.WriteLine("3. Calculate total calories");
            Console.WriteLine("4. Scale the recipe");
            Console.WriteLine("5. Reset quantities");
            Console.WriteLine("6. Clear the recipe");
            Console.WriteLine("7. Exit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    recipe.EnterRecipe();
                    break;
                case 2:
                    recipe.DisplayRecipe();
                    break;
                case 3:
                    int totalCalories = recipe.CalculateTotalCalories();
                    Console.WriteLine("Total Calories: " + totalCalories);
                    break;
                case 4:
                    Console.WriteLine("Enter the scale factor (0.5, 2, or 3):");
                    double scaleFactor = double.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(scaleFactor);
                    break;
                case 5:
                    recipe.ResetQuantities();
                    break;
                case 6:
                    recipe.ClearRecipe();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
