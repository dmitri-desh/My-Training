using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsAndGenerics
{
    class Program
    {
        
        static string RandomString()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int size = random.Next(10, 20000);
            StringBuilder builder = new StringBuilder();
            builder.Clear();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(random.Next(13, 256));
                builder.Append(ch);
            }

            return builder.ToString();
        }
         static void Main(string[] args)
        {
           
           // 1.	максимальная скорость поиска и извлечения искомой строки  
            string searchValue = "";
            Hashtable table = new Hashtable();
            string curStr;
            Console.WriteLine("Start generate strings...");
            var startAddTime = DateTime.Now;
            for (int i = 1; i <= 100000; i++)
            {
                curStr = RandomString();
                table.Add(i, curStr);
                if (i == 25000) searchValue = curStr;
            }
            var endAddTime = DateTime.Now;
            var res = table.ContainsValue(searchValue);
            var endSearchTime = DateTime.Now;
            var addTime = endAddTime - startAddTime;
            var searchTime = endSearchTime - endAddTime;
            Console.WriteLine("Adding Time is {0} sec. Search Time is {1} sec.", addTime, searchTime);
            if (res) { Console.WriteLine("Binago!!! Search Value:"); 
                       Console.WriteLine("{0}", searchValue);
                       Console.WriteLine("exists in table.");
                      }
                 else {
                       Console.WriteLine("Error!!! Search Value:");
                       Console.WriteLine("{0}", searchValue);
                       Console.WriteLine("not exists in table.");
                      }

            // 2.	максимальная скорость сохранения данных в коллекции 
            Dictionary<int, string> dict = new Dictionary<int, string>();
            startAddTime = DateTime.Now;
            for (int i = 1; i <= 50000; i++)
            {
                curStr = RandomString();
                dict.Add(i, curStr);
                if (i == 25000) searchValue = curStr;
            }
            endAddTime = DateTime.Now;
            res = dict.ContainsValue(searchValue);
            endSearchTime = DateTime.Now;
            addTime = endAddTime - startAddTime;
            searchTime = endSearchTime - endAddTime;
            Console.WriteLine("Adding Time is {0} sec. Search Time is {1} sec.", addTime, searchTime);
            if (res)
            {
                Console.WriteLine("Binago!!! Search Value:");
                Console.WriteLine("{0}", searchValue);
                Console.WriteLine("exists in dictionary.");
            }
            else {
                Console.WriteLine("Error!!! Search Value:");
                Console.WriteLine("{0}", searchValue);
                Console.WriteLine("not exists in dictionary.");
            }
            
            // 3.Реализуйте свою коллекцию с итератором. Коллекция работает только с целыми числами.
            //   При итерации проход по элементам должен заканчиваться, если встречается отрицательное число.
            var randEnum = new MyEnumerator();
            foreach (var cur in randEnum)
                Console.Write("{0}, ", cur);
        }

    }
}
