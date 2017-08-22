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
            int n = 9;
            int k = 3;
            // формирую список рандомных значений и их пар, соответсвенно 
            List<int> arrRand = new List<int>();
            Random rand = new Random((int)Stopwatch.GetTimestamp());
            for (int i = 0; i < k; i++)
                arrRand.Add(rand.Next());
            for (int i = k; i < n; i = i + 2)
            {
                arrRand.Add(rand.Next());
                arrRand.Add(arrRand[i]);
            }
            // рандомно перетасовываем список
            var sorted = arrRand.OrderBy(a => Guid.NewGuid()).ToList();
            arrRand.Clear();
            arrRand.AddRange(sorted);
            // исходный массив
            int[] arr = arrRand.ToArray();
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0, 12}", arr[i]);
                if (i > 0 && i % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            // формирование окончено
            bool flag = false;
            List<int> idxPair = new List<int>();
            // поиск k элементов, не имеющих пары
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (arr[i] == arr[j])
                    {
                        idxPair.Add(j);
                        flag = true;
                        break;
                    }
             if (!flag && !idxPair.Contains(i))
                Console.Write("{0}-й {1, 12} | ", i+1, arr[i]);
             flag = false;
            }
            Console.WriteLine();
        }
    }
}
