using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.collections.generics
{
        interface IMealPlan
        {
            string GetMeal(); // Returns meal type
        }

        // Vegetarian meal implementation
        class VegetarianMeal : IMealPlan
        {
            public string GetMeal()
            {
                return "Vegetarian Meal";
            }
        }

        // Vegan meal implementation
        class VeganMeal : IMealPlan
        {
            public string GetMeal()
            {
                return "Vegan Meal";
            }
        }

        // Generic Meal class with constraints
        class Meal<T> where T : IMealPlan, new()
        {
            // Creates and displays meal
            public void GenerateMeal()
            {
                T meal = new T();          // new() constraint
                Console.WriteLine(meal.GetMeal());
            }
        }

        internal class MealPlanner
        {
            public static void Main(string[] args)
            {
                // Generate vegetarian meal
                Meal<VegetarianMeal> vegMeal = new Meal<VegetarianMeal>();
                vegMeal.GenerateMeal();

                // Generate vegan meal
                Meal<VeganMeal> veganMeal = new Meal<VeganMeal>();
                veganMeal.GenerateMeal();
            }
        }

    }