using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public delegate string Filter(string dirsPattern, string filesPattern);

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new DirectoryInfo(@ConfigurationManager.AppSettings["root"]);

            if (root.Exists)
            {
               var dirsFiles = new FileSystemVisitor(root);

                foreach (var fd in dirsFiles.GetTree())
                {
                    Console.WriteLine(fd.ToString());
                }

            }
            else Console.WriteLine("Directory {0} does not exist", root.FullName);
        }
    }
}
