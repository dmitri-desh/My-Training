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
                // Task02 Calculation
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}-ое число Фибоначчи = {1}", i, Calculation.GetFibonacci(i));
                Console.WriteLine("{0}! = {1}", i, Calculation.GetFactorial(i));

                // Task02 ObjCounter
                ObjCounter obj1 = new ObjCounter();
                ObjCounter obj2 = new ObjCounter();
                ObjCounter obj3 = new ObjCounter();
                ObjCounter obj4 = new ObjCounter();
                ObjCounter obj5 = new ObjCounter();
                ObjCounter obj6 = new ObjCounter();
                obj1.Dispose();
                obj3.Dispose();
                Console.WriteLine("Образовано {0} объектов класса", obj1.GetObjectsCount());
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректное число");
            }

        }
    }
}
