using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // ThirdExample();
            FourthExample();
           // Console.ReadLine();
        }
        private static void ThirdExample()
        {
            HashCodeString code = new HashCodeString { Original = "\uA0A2\uA0A2" };
            var result = code.CheckString("hello");
            Debug.Assert(!result);
            result = code.CheckString("");
            Debug.Assert(!result);
        }
        class HashCodeString
        {
            public string Original { get; set; }
            public bool CheckString(string inputString)
            {
                return Original.GetHashCode() == inputString.GetHashCode();
            }
        }
        private static void FourthExample()
        {
            KeyValuePair<int, int> value1 = new KeyValuePair<int, int>(10, 20);
            KeyValuePair<int, int> value2 = new KeyValuePair<int, int>(10, 30);
            Console.WriteLine(string.Format("HashCode value1 is {0}, HashCode value2 is {1}", 
                                             value1.GetHashCode(), value2.GetHashCode()
                                           )
                             );

            KeyValuePair<int, string> value3 = new KeyValuePair<int, string>(10, "aaa");
            KeyValuePair<int, string> value4 = new KeyValuePair<int, string>(10, "bbb");
            Console.WriteLine(string.Format("HashCode value3 is {0}, HashCode value4 is {1}",
                                            value3.GetHashCode(), value4.GetHashCode()
                                           ));
        }
    }
}
