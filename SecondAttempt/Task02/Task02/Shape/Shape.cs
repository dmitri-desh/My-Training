using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Shape
{
    abstract class Shape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public abstract void Draw();
        public virtual double Area()
        {
            return 0;
        }
    }
}
