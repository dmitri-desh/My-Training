using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = Directory.GetCurrentDirectory();
                var targetDir = @ConfigurationManager.AppSettings["targetDirectory"];
                var targetFile = @ConfigurationManager.AppSettings["targetFile"];
                if (!Directory.Exists(targetDir))
                     Directory.CreateDirectory(targetDir);
                Environment.CurrentDirectory = (targetDir);

                var fileName = $@"{ Environment.CurrentDirectory }\{targetFile}";
                var text = new TextToDictionary();
                var words = text.GetWords(fileName);
                var dict = text.GetDictionary(words);
/*
                foreach (KeyValuePair<string, int> kvp in dict)
                     Console.WriteLine($"{kvp.Key} {kvp.Value}");
  */              

            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.ToString()}");
            }
            
        }
    }
}
