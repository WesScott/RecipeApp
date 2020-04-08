using System;

namespace CSharp_Recipe_App
{
    class Ingredient
    {
        // Constructor with all 3 params
        public Ingredient(string name, double amount, string measurement){
            this.Name = name;
            this.Amount = amount;
            this.Measurement = measurement;
        }

        // Instance Variables
        public string Name;
        public double Amount;
        public string Measurement;

        // Class methods
        public void setName(string name){
            this.Name = name;
        }
        public string getName(){
            return this.Name;
        }

        public void setAmount(double amount){
            this.Amount = amount;
        }
        public double getAmount(){
            return this.Amount;
        }

        public void setMeasurement(string measurement){
            this.Measurement = measurement;
        }
        public string getMeasurement(){
            return this.Measurement;
        }
        public void printIngredient(){
            Console.WriteLine(this.getName() + ": " + this.getAmount() + this.getMeasurement());
        }
    }
}