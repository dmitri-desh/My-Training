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
                            where sentence.Count() > 0 && sentence.Last().ToString().Trim() == "?"
                            select sentence;
            foreach (var sentence in sentences)
            {
                ShowSentence(sentence);
            }
            Console.WriteLine();


            var words = from sentence in sentences
                        where sentence.ToList().Any(x => (x is IWord ? (x as IWord).ToString().Length : 0)== length) 
                        select sentence.ToList().Distinct().ToString();

            foreach (var word in words)
            {
                Console.Write("{0}", word);
            }
       
        }



    }
}