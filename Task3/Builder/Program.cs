using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticStation;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Builder builder = new CustomBuilder();
            Director director = new Director(builder);
            director.Construct();
            builder.GetResult();

            Console.ReadLine();
        }
    }
}
