using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Ingredient : IComparable, IIngredient 
    {
        public string Name { get; set; }
        public double Calorie { get; set; }
        public double Weight { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

     public Ingredient()
        {

        }
    public Ingredient (string name, double calorie, double weight, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calorie = calorie / 100;
            Weight = weight;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
    public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Ingredient other = obj as Ingredient;
            if (other != null)
            {
                return this.Weight.CompareTo(other.Weight);
            }
            else
            {
                throw new ArgumentException("Ingredient is not valid.");
            }

        }

        /*
        public int CompareTo(Ingredient other)
        {
            if ((double)this.Weight > (double)other.Weight) return 1;
            if ((double)this.Weight < (double)other.Weight) return -1;
            else return 0;

        }
        */

    }
}