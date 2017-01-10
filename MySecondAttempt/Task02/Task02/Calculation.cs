using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
   static class Calculation
    {
        static int GetFibonacci(int i)
        {
            if (i <= 1) return i;
            else return GetFibonacci(i - 2) + GetFibonacci(i - 1);
        }

        static int GetFactorial(int i)
        {
            if (i == 1) return i;
            else return GetFactorial(i - 1) * i;
        }
    }
}