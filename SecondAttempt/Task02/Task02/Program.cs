using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            try
            {
                
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}-ое число Фибоначчи = {1}", i, Calculation.GetFibonacci(i));
                Console.WriteLine("{0}! = {1}", i, Calculation.GetFactorial((ulong)i));
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректное число");
            }

        }
    }
}
