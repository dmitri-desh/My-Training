using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 23;
            int k = 3;
            // формирую массив
            List<int> arrRand = new List<int>();
            Random rand = new Random((int)Stopwatch.GetTimestamp());
            for (int i = 0; i < k; i++)
                arrRand.Add(rand.Next());
            for (int i = k; i < n; i = i + 2)
            {
                arrRand.Add(rand.Next());
                arrRand.Add(arrRand[i]);
            }
            var sorted = arrRand.OrderBy(a => Guid.NewGuid()).ToList();
            arrRand.Clear();
            arrRand.AddRange(sorted);
            int[] arr = arrRand.ToArray();
            for (int i = 0; i < n; i++)
                 Console.Write("{0} ", arr[i]);
        // массив сформирован

        }
    }
}
