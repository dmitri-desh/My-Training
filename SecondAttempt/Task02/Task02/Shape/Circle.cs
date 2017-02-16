using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Shape
{
    class Circle : Shape
    {
        public double R { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Draw Circle!");
            double x = 0;
            double y = Math.Sqrt(Math.Pow(R, 2) - Math.Pow(x, 2));
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(R, 2);
        }
        public Circle (double x, double y, double r)
        {
            X = x;
            Y = y;
            R = r;
        }
    }
}
