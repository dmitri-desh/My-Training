using System;
using System.Configuration;
using System.IO;
using System.Linq;

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
                var inputFile = @ConfigurationManager.AppSettings["inputFile"];
                
                if (!Directory.Exists(targetDir))
                     Directory.CreateDirectory(targetDir);
                Environment.CurrentDirectory = (targetDir);

                var inputFileName = $@"{ Environment.CurrentDirectory }\{inputFile}";
               
                var text = new TextToDictionary();
                var words = text.GetWords(inputFileName);
                if (words.Count() > 0)
                  text.GetDictionary(words);
            }
            catch (Exception e)
            {
                // Console.WriteLine($"The process failed: {e.ToString()}");
                return;
            }
            
        }
    }
}
