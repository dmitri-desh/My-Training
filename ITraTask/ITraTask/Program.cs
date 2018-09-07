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
               
                var strToRemove1 =  "'s";
                var strToRemove2 = "- ";
                var pattern = @"\s+";
                var defaultSeparator = " ";
                Regex regex = new Regex(pattern);
                char[] separators = { ' ', ',', '.', '!', '?', '"', '\'', ';', ':', '(', ')' };
                var fileName = $@"{ Environment.CurrentDirectory }\{targetFile}";

                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                            break;
                        line = line.Replace(strToRemove1, String.Empty);
                        line = line.Replace(strToRemove2, String.Empty);
                        line = regex.Replace(line, defaultSeparator);
                        line = line.ToLower();
                        var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                         Console.WriteLine(word);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.ToString()}");
            }
            
        }
    }
}
