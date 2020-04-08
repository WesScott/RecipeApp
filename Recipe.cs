using System;
using System.Collections.Generic;

namespace CSharp_Recipe_App
{
    class Recipe
    {
        // Constructor w/ all params
        public Recipe(string name, string desc, string instr, List<Ingredient> list){
            this.Name = name;
            this.Description = desc;
            this.Instructions = instr;
            this.IngredientList = list;
        }

        // Instance Variables
        public string Name;
        public string Description;
        public string Instructions;
        public List<Ingredient> IngredientList;

        // Class Methods
        public void setName(string name){
            this.Name = name;
        }
        public string getName(){
            return this.Name;
        }

        public void setDescription(string desc){
            this.Description = desc;
        }
        public string getDescription(){
            return this.Description;
        }

        public void setInstructions(string instr){
            this.Instructions = instr;
        }
        public string getInstructions(){
            return this.Instructions;
        }

        public List<Ingredient> getIngredientList(){
            return this.IngredientList;
        }
        public void setIngredientList(List<Ingredient> list){
            this.IngredientList = list;
        }
        public void addIngredient(Ingredient ingredient){
            this.IngredientList.Add(ingredient);
        }
        public void printRecipe(){
            Console.WriteLine(this.getName());
            Console.WriteLine(this.getDescription());
            foreach(Ingredient i in this.getIngredientList()){
                i.printIngredient();
            }
            Console.WriteLine(this.getInstructions());
        }
    }
}