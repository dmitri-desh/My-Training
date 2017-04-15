using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Shape
{
     class Shape : IDrawn
    {
        public double X { get; set; }
        public double Y { get; set; }
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks!");
        }
        public virtual double GetArea()
        {
            return -1;
        }
    }
}
