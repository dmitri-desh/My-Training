﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
   public static class Calculation
    {
        public static int GetFibonacci(int i)
        {
            if (i <= 1) return i;
            else return GetFibonacci(i - 2) + GetFibonacci(i - 1);
        }

        public static ulong GetFactorial(ulong i)
        {
            if (i == 1) return (ulong)i;
            else return GetFactorial(i - 1) *(ulong)i;
        }
    }
}