using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 20;
            var s = Calculation.GetFactorialFor(n);
            Console.WriteLine("Факториал (цикл) {0}!={1}", n, s);
            s = Calculation.GetFactorialRecur(n);
            Console.WriteLine("Факториал (рекурсия) {0}!={1}", n, s);
        }
    }
}
