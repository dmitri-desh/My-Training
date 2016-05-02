using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace TextBuilder1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Symbol s = new Symbol("A");
            string p = s.Chars;

            Word w1 = new Word("прывет");

            foreach (var z in w1)
            {
                Console.WriteLine(z.Chars);
            }

            Console.WriteLine(w1.Chars);
            */
            Builder builder = new CustomTextBuilder();
            Director director = new Director(builder);
            director.Construct();
            builder.GetResult();



            Console.ReadLine();
        }
    }
}
