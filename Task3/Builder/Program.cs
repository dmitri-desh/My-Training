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
            List<IPort> ports = new List<IPort>() { new TestPort(), new TestPort() };
            List<ITerminal> terminals = new List<ITerminal>() { };

            TestStation s = new TestStation(terminals, ports);

            s.Add(new TestTerminal(new PhoneNumber("00-000-00-00")));
            s.Add(new TestTerminal(new PhoneNumber("11-111-11-11")));

            foreach (var t in terminals)
            {
                t.Plug();
            }

            //terminals[0].Call( new PhoneNumber("11-111-11-11"));
            //terminals[0].Answer();
            terminals[1].Drop();
            Console.ReadLine();

            Builder builder = new CustomBuilder();
            Director director = new Director(builder);
            director.Construct();
            builder.GetResult();



            Console.ReadLine();
        }
    }
}
