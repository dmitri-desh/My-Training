using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Shape
{
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle!");
        }
        public override double GetArea()
        {
            return Width * Height;
        }
        public Rectangle (double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
