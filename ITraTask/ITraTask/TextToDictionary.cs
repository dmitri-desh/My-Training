using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TextToDictionary
    {
        public IEnumerable<string> GetWords(string fileName)
        {
            var strToRemove1 = "'s";
            var strToRemove2 = "- ";
            var pattern = @"\s+";
            var defaultSeparator = " ";
            Regex regex = new Regex(pattern);
            char[] separators = { ' ', ',', '.', '!', '?', '"', '\'', ';', ':', '(', ')' };
            var words = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                        break;
                    line = line.Replace(strToRemove1, String.Empty);
                    line = line.Replace(strToRemove2, String.Empty);
                    line = regex.Replace(line, defaultSeparator);
                    line = line.ToLower();
                    var lineWords = line.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
               //     foreach (var word in lineWords)
               //       Console.WriteLine(word);
                    words.AddRange(lineWords);
                }
             //   Console.WriteLine($"Count Words: {words.Count()}");
                return words;
            }
        }

        public IDictionary<string, int> GetDictionary(IEnumerable<string> words)
        {
            var dict = new Dictionary<string, int>();
            
            foreach(var word in words.OrderBy(w => w))
                if (!dict.ContainsKey(word))
                    dict.Add(word, 1);
                else
                    dict[word] = dict[word] + 1;

            var result = dict.GroupBy(item => item.Key.ToString()[0])
                .ToDictionary(key => key.Key, value => value.Select(i => i.Value).OrderByDescending(a => a)).ToList();
            foreach (var res in result)
            {
                Console.WriteLine($"{res.Key}");
                foreach (var cur in res.Value)
                    Console.WriteLine($"{cur.ToString()}");
            }
                return dict;
        }
    }
}
