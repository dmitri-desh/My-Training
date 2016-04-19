using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Ingredient : Item, IHasCalories
    {
      //  public new string Name { get; protected set; }
        public double Carbohydrates { get; protected set; }
        public double Proteins { get; protected set; }
        public double Fats { get; protected set; }
   
        public double Calories { get; protected set; }
        public Ingredient (string name, double weight, double calories, double carbohydrates, double proteins, double fats) : base (name, weight)
        {
         //   this.Name = name;
            this.Calories = calories;
            this.Carbohydrates = carbohydrates;
            this.Proteins = proteins;
            this.Fats = fats;
        }

        public Ingredient(string name, double weight) : base(name, weight)
        {
          
        
        }

        public override string ToString()
        {
            return Name.PadRight(16, ' ') + "\t" + Calories.ToString("N2").PadLeft(14, ' ')
                                          + "\t" + Weight.ToString("N2").PadLeft(6, ' ')
                                          + "\t" + Proteins.ToString("N2").PadLeft(6, ' ')
                                          + "\t" + Fats.ToString("N2").PadLeft(6, ' ')
                                          + "\t" + Carbohydrates.ToString("N2").PadLeft(6, ' ');
        }

    }
}