using System;
using System.Xml;
using System.IO;

namespace CSharp_Recipe_App
{
    class XMLWriter{
        // Given a recipe Object, write the recipe to an xml file
        // we will assume that the filename can be set as the recipe name,
        // meaning when a user is adding a recipe, they cannot have multiple
        // recipes of the same name.
        public void writeToXML(Recipe recipe){
            string filename = genRecipeName(recipe);
            XmlWriter writer = XmlWriter.Create("recipes/"+filename+".xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("recipe");

            writer.WriteStartElement("recipe-name");
            writer.WriteString(recipe.getName());
            writer.WriteEndElement();

            writer.WriteStartElement("description");
            writer.WriteString(recipe.getDescription());
            writer.WriteEndElement();

            writer.WriteStartElement("ingredients");

            foreach (Ingredient i in recipe.getIngredientList()){
                writer.WriteStartElement("Ingredient");
                writer.WriteStartElement("ingredient-name");
                writer.WriteString(i.getName());
                writer.WriteEndElement();
                writer.WriteStartElement("amount");
                writer.WriteString(Convert.ToString(i.getAmount()));
                writer.WriteEndElement();
                writer.WriteStartElement("measurement");
                writer.WriteString(i.getMeasurement());
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteStartElement("instructions");
            writer.WriteString(recipe.getInstructions());
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

        }
        // Given a recipe object, will return a modified string for filename creation
        public string genRecipeName(Recipe recipe){
            char[] invalidFileChars = Path.GetInvalidFileNameChars();
            string str = recipe.getName();
            string newStr = str.Trim(invalidFileChars).ToLower();
            Console.Out.WriteLine(newStr);
            return newStr;
        }
    }
}