using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
<<<<<<< HEAD
            var root = @ConfigurationManager.AppSettings["root"];
            Console.WriteLine("Root directory is {0}", root);
            FileSystemVisitor explorer = new FileSystemVisitor(root);
            explorer.GetDirsFilesTree();
            foreach (var curStr in explorer.PrintDirectoriesTree())
                   Console.WriteLine("{0}", curStr);
            
=======
            var root = new DirectoryInfo( @ConfigurationManager.AppSettings["root"]);
            
            if (root.Exists)
            {
                var dirsFiles = new FileSystemVisitor(root);
                dirsFiles.ExploreTree(root);
                
                foreach (var fd in dirsFiles.GetTree())
                {
                    Console.WriteLine(fd.ToString());
                }

            }
            else Console.WriteLine("Directory {0} does not exist", root.FullName);
>>>>>>> origin/New
        }
    }
}
