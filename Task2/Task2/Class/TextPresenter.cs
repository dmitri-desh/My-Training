using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class TextPresenter
    {
        public Text TextResult { get; }
        public TextPresenter(Text text)
        {
            TextResult = text;
        }
        public void ShowAll ()
        {
           foreach (var sentence in TextResult.Sentences)
            {
                ShowSentence(sentence);
            }
        }
        public void ShowSentence (ISentence sentence)
        {
            int bufferLength = 10000;
            StringBuilder buffer = new StringBuilder(bufferLength);
            string pattern = @"\s+";
            string target = " ";
            Regex regex = new Regex(pattern);
            buffer.Clear();
            foreach (var sentenceItem in sentence)
            {
                buffer.Append(sentenceItem is IWord ? " " + sentenceItem.Chars.ToString() : sentenceItem.Chars.ToString().TrimStart());
            }
            Console.WriteLine(regex.Replace(buffer.ToString().TrimStart(), target));
        }
        public void GetOrderedSentences ()
        {

            var sentences = from sentence in TextResult.Sentences
                            orderby sentence.Count(x => x is IWord)
                            select sentence;
            foreach (var sentence in sentences)
            {
                ShowSentence(sentence);
            }
        }
        public void GetWordsInInterrogationSentences (int length)
        {

            var sentences = from sentence in TextResult.Sentences
                            where sentence.LastOrDefault().ToString().Trim() == "?"
                          // where sentence.LastOrDefault(x => (x is IPunctuation ? (x as IPunctuation).ToString().Trim():" ") == "?")
                            select sentence;
            
            var words = from sentence in sentences
                        where sentence.ToList().ToString().Length == length
                        select sentence.Distinct();
           foreach (var word in words)
            {
                Console.Write("{0} ", word);
            }
            
           /*
            foreach (var sentence in sentences)
            {
                ShowSentence(sentence);
            }
            */
            Console.WriteLine();
        }



    }
}