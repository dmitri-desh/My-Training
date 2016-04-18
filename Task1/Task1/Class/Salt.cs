using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Salt : Item //, ISalt
    {
      //  public new string Name { get; protected set; }

     
        public Salt(string name, double weight) : base (name, weight)
        {
         //   this.Name = name;
    
        }

        public override string ToString()
        {
            return Name.PadRight(16, ' ') +"\t"+ " ".PadLeft(14, ' ') 
                                          +"\t"+ Weight.ToString("N2").PadLeft(6, ' ');
        }
    }
}