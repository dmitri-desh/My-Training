using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var watchPath = System.Configuration.ConfigurationManager.AppSettings["DirectoryWatching"];
            Console.WriteLine("Directory watched: {0}", watchPath);
            var appManager = new BL.AppManager(new System.IO.FileSystemWatcher(watchPath, "*.csv"));
           
            appManager.Run();
            Console.ReadLine();
            appManager.Stop();
        }
    }
}
