using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Vegetable : Item, IHasCalories, IHasWeight
    {
        public new string Name { get; protected set; }
        public int Qty { get; protected set; }
        public Measures Measure { get; protected set; }
        public double SpecificWeight { get; protected set; }
        public double Calories { get; protected set; }
        public CuttingMethods CuttingMethod { get; protected set; }

        public double GetWeightCalculated()
        {
            if (this.Qty > 0 && this.Measure == Measures.Pcs && this.SpecificWeight > 0)
              return this.Qty * this.SpecificWeight;
            else
              return 0;
        }

        public double GetCaloriesCalculated()
        {
                 if (this.Qty > 0 && this.Measure == Measures.Pcs && this.SpecificWeight > 0)
                    return this.Qty * this.SpecificWeight * this.Calories / 100;
                else
                    return 0;
        }
        public Vegetable (string name, int qty, Measures measure, double specificweight, double calories) : base(name)
        {
            this.Name = name;
            this.Qty = qty;
            this.Measure = measure;
            this.SpecificWeight = specificweight;
            this.Calories = calories;
        }
        public Vegetable(string name, int qty, Measures measure, double specificweight, double calories, CuttingMethods cuttingmethod) : base(name)
        {
            this.Name = name;
            this.Qty = qty;
            this.Measure = measure;
            this.SpecificWeight = specificweight;
            this.Calories = calories;
            this.CuttingMethod = cuttingmethod;
        }
        public override string ToString()
        {
            return Name.PadRight(10, ' ') + "\t" + Qty.ToString().PadLeft(5, ' ')
                                          + "\t" + Measure.ToString().PadLeft(6, ' ')
                                          + "\t" + GetWeightCalculated().ToString("N2").PadLeft(6, ' ')
                                          + "\t" + Calories.ToString("N2").PadLeft(6, ' ')
                                          + "\t" + (CuttingMethod > 0 ? CuttingMethod.ToString().PadLeft(15, ' ') : "");
        }
    }
}