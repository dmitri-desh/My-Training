using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Fdata f = new Fdata() {X0 = 1,Y0 = 10, Color = 0x2727FF, Type=Figure.Rectangle };
            Console.WriteLine("Координаты: {0} и {1}; цвет: {2}; фигура: {3}", f.X0, f.Y0, f.Color, f.Type);

        }
    }
}
