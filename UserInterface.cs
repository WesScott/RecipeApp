using System;
using System.IO;
using System.Collections.Generic;

namespace CSharp_Recipe_App
{
    class UserInterface
    {
        // Instance Variables
        List<Recipe> Recipes;

        // Constructor
        public UserInterface(List<Recipe> recipes){
            this.Recipes = recipes;
        }

        // Class methods
        public void mainMenu(){
            while(true){
            Console.Out.WriteLine("What would you like to do?\n");
            
                Console.Out.WriteLine("1) List All Recipes");
                Console.Out.WriteLine("2) View a Recipe");
                Console.Out.WriteLine("3) Add a Recipe");
                Console.Out.WriteLine("5) Quit");

                string userIn = Console.ReadLine();
                if (userIn == "5"){
                    break;
                }

                processChoice(userIn);
            }
        }

        public void processChoice(string input){
            switch(input){
                case "1":
                    showRecipes();
                    break;
                case "2":
                    viewRecipe();
                    break;
                case "3":
                    addRecipe();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        public void showRecipes(){
            foreach(Recipe recipe in this.Recipes){
                Console.WriteLine(recipe.getName());
            }
        }

        public void viewRecipe(){
            Console.Out.WriteLine("\nWhat Recipe would you like to view? ");
            string userIn = Console.ReadLine();
            foreach(Recipe recipe in this.Recipes){
                if(userIn == recipe.getName()){
                    recipe.printRecipe();
                    break;
                }
            }
        }

        public void addRecipe(){
            Console.Out.WriteLine("\nWhat is the name of your recipe? ");
            string recipeName = Console.ReadLine();

            Console.Out.WriteLine("\nWrite the description of your recipe :");
            string recipeDesc = Console.ReadLine();

            List<Ingredient> ingredients = addIngredients();

            Console.Out.WriteLine("\nWrite the instructions for cooking your recipe: ");
            string recipeInstr = Console.ReadLine();

            Recipe r = new Recipe(recipeName,recipeDesc,recipeInstr,ingredients);

            XMLWriter writer = new XMLWriter();
            writer.writeToXML(r);

            this.Recipes.Add(r);
        }

        public List<Ingredient> addIngredients(){
            List<Ingredient> ings = new List<Ingredient>();
            Console.Out.WriteLine("\nWhat is the name of your first ingredient: ");
            string ing1Name = Console.ReadLine();

            Console.Out.WriteLine("What is the amount of "+ing1Name+"you need?");
            string readAmt = Console.ReadLine();
            double ing1amt = Convert.ToDouble(readAmt);

            Console.Out.WriteLine("What is the unit of measurement for this ingredient?");
            string ing1meas = Console.ReadLine();

            ings.Add(new Ingredient(ing1Name,ing1amt,ing1meas));

            int count = 1;
            while(true){
                Console.Out.WriteLine("\nWhat is the name of ingredient #"+count+"? ");
                Console.Out.WriteLine("Type 'done' if there are no more ingredients");
                string ingName = Console.ReadLine();
                if (ingName == "done"){
                    break;
                }

                Console.Out.WriteLine("What is the amount of "+ingName+" you need?");
                string amt = Console.ReadLine();
                double ingAmt = Convert.ToDouble(amt);

                Console.Out.WriteLine("What is the unit of measurement for this ingredient?");
                string ingMeas = Console.ReadLine();

                ings.Add(new Ingredient(ingName,ingAmt,ingMeas));
            }
            return ings;
        }

    }
}