using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Shape
{
    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw Triangle!");
        }
    public Triangle(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
