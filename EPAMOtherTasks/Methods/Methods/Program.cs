using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = @ConfigurationManager.AppSettings["root"];
            Console.WriteLine("Root directory is {0}", root);
            FileSystemVisitor explorer = new FileSystemVisitor(root);
            explorer.GetDirsFilesTree();
            foreach (var curStr in explorer.PrintDirectoriesTree())
                   Console.WriteLine("{0}", curStr);
            
        }
    }
}
