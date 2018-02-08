using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public static class Calculation
    {
       public static long GetFactorialRecur(int i)
        {
            checked
            {
                if (i == 1) return (long)i;
                else return GetFactorialRecur(i - 1) * (long)i;
            }
        }
       public static long GetFactorialFor(int n)
        {
            checked
            {
                long res = 1;
                for (int i = 2; i < n + 1; i++)
                     res *= i;

                return res;
            }
        }
    }
}
