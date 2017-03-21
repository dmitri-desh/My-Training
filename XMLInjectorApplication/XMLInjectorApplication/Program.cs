using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;


namespace XMLInjectorApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = ConfigurationManager.AppSettings["pathToSourceFile"];
            StreamReader reader = null;
            Console.WriteLine("Reading text {0}", fileName);
            try
            {
                reader = File.OpenText(fileName);
               // text = parser.Parse(reader);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading. {0}", e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }
    }
}
