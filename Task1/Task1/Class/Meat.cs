using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Meat : Item, IHasWeight, IHasCalories
    {
        public new string Name { get; protected set; }
        public double Weight { get; protected set; }
        public double Calories { get; protected set; }
        public double GetCaloriesCalculated ()
        {
              return this.Weight * this.Calories / 100;
        }
        public double GetWeightCalculated()
        {
            return this.Weight;
        }
        public Meat (string name, double weight, double calories) : base (name)
        {
            this.Name = name;
            this.Weight = weight;
            this.Calories = calories;
        }
        public override string ToString()
        {
            return Name.PadRight(10, ' ') + "\t" + " ".PadLeft(5, ' ')
                                          + "\t" + " ".PadLeft(6, ' ')
                                          + "\t" + GetWeightCalculated().ToString("N2").PadLeft(6, ' ')
                                          + "\t" + Calories.ToString("N2").PadLeft(6, ' ');
        }
    }
}