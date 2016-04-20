using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Spice : Item
    {
        public new string Name { get; protected set; }
        public int Qty { get; protected set; }
        public Measures Measure { get; protected set; }
        public Spice (string name, int qty, Measures measure) : base(name)
        {
            this.Name = name;
            this.Qty = qty;
            this.Measure = measure;
        }
        public Spice(string name) : base(name)
        {
            this.Name = name;
           
        }
        public override string ToString()
        {
            return Name.PadRight(10, ' ') + (Qty > 0 ? "\t" + Qty.ToString().PadLeft(5, ' '):"")
                                          + (Measure > 0 ? "\t" + Measure.ToString().PadLeft(6, ' '):"");
        }
    }
}