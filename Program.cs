using System;
using System.IO;
using System.Collections.Generic;

namespace CSharp_Recipe_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prgram Start.");
            XMLParser parser = new XMLParser();
            XMLWriter writer = new XMLWriter();

            // Grab all recipe.xmls from the recipes directory, and read them in as listed recipe objects
            List<Recipe> AllRecipes = new List<Recipe>();
            string[] filePaths = Directory.GetFiles(@"recipes/");
            for (int i = 0; i < filePaths.Length; i++){
                AllRecipes.Add(parser.ParseToRecipe(filePaths[i]));
            }

            /* List names of all recipes we read in:
            foreach (Recipe recipe in AllRecipes){
                Console.WriteLine(recipe.getName());
            }
            */
            
            /* Testing the XMLWriter
            List<Ingredient> testIngList = new List<Ingredient>();
            Ingredient test1 = new Ingredient("testwrite1",1,"cups");
            Ingredient test2 = new Ingredient("test wrtie 2", 2.5, "tsp");
            testIngList.Add(test1);
            testIngList.Add(test2);
            Recipe testWriter = new Recipe("Does this write","lets see", "instruct me",testIngList);
            writer.writeToXML(testWriter);
            */

            // TODO: Creat a menu or other interface to allow user to choose what
            // recipe to view, or to create/delete recipe.
            UserInterface menu = new UserInterface(AllRecipes);
            menu.mainMenu();
        }
    }
}
