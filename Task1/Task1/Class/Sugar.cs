using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Sugar : Item, IHasCalories
    {
      //  public new string Name { get; protected set; }
        public double Carbohydrates { get; protected set; }
        public double Calories { get; protected set; }
        public Sugar(string name, double weight, double calories, double carbohydrates) : base (name, weight)
        {
           // this.Name = name;
            this.Calories = calories;
            this.Carbohydrates = carbohydrates;
            
        }
        public override string ToString()
        {
            return Name.PadRight(16, ' ') + "\t" + Calories.ToString("N2").PadLeft(14, ' ')
                                          + "\t" + Weight.ToString("N2").PadLeft(6, ' ')
                                          + "\t" + " ".PadLeft(6, ' ')
                                          + "\t" + " ".PadLeft(6, ' ')
                                          + "\t" + Carbohydrates.ToString("N2").PadLeft(6, ' ');
        }
    }
}