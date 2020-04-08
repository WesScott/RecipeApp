using System;
using System.Xml;
using System.Collections.Generic;

namespace CSharp_Recipe_App
{
    class XMLParser{
        // Returns a full recipe object if given a valid recipe.xml file
        public Recipe ParseToRecipe(string file){

            string recipeName = parseRecipeName(file);
            //Console.WriteLine(recipeName);

            string recipeDesc = parseRecipeDesc(file);
           // Console.WriteLine(recipeDesc);

            string recipeInstr = parseRecipeInstr(file);
            //Console.WriteLine(recipeInstr);

            List<Ingredient> recipeIngs = parseRecipeIngs(file);
            //Console.WriteLine(recipeIngs.ToString());

            Recipe r = new Recipe(recipeName,recipeDesc,recipeInstr,recipeIngs);
            
            return r;
           
        }
        // Sub-Function to grab recipe name from given xml
        public string parseRecipeName(string xml){
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList name = doc.GetElementsByTagName("recipe-name");
            return name[0].InnerXml;
        }
        // Sub-Function to grab recipe Description from given xml
        public string parseRecipeDesc(string xml){
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList name = doc.GetElementsByTagName("description");
            return name[0].InnerXml;
        }
        // Sub-Function to grab recipe Instructions from given xml
        public string parseRecipeInstr(string xml){
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList name = doc.GetElementsByTagName("instructions");
            return name[0].InnerXml;
        }
        // given a recipe.xml, it will return an Ingredient List for a recipe
        public List<Ingredient> parseRecipeIngs(string xml){
            List<Ingredient> ingredients = new List<Ingredient>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            XmlNodeList ingList = doc.GetElementsByTagName("Ingredient");
            int numIngs = ingList.Count;
            for(int i = 0; i < numIngs; i++){
                Ingredient ing = stripIngredientInfo(ingList[i]);
                ingredients.Add(ing);
            }
            return ingredients;
        }
        // Given an entire xml element block of <Ingredient>, it return a programtic Ingredient object.
        public Ingredient stripIngredientInfo(XmlNode element){
            XmlNodeList ingList = element.ChildNodes;
            string ingName = (ingList[0].InnerText);
            double ingAmount = Convert.ToDouble(ingList[1].InnerText);
            string ingMeasurement = (ingList[2].InnerText);
            Ingredient i = new Ingredient(ingName,ingAmount,ingMeasurement);
            return i;
        }
    }
}