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
                        select sentence.ToList().ToString();

            var distinctWords = from word in words
                                select word.Distinct();

            foreach (var word in distinctWords)
            {
                Console.Write("{0} ", word);
            }
      
        }
     // ToDo   
        public void RemoveWordsByLength (int length)
        {
            
            string pattern = @"\b[b-d f-h j-n p-t v-x z]";
            
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            /*
             var sentences = from sentence in TextResult.Sentences
                            select sentence;
            // int i = 0;

            var words = from sentence in sentences
                        where sentence.ToList().Any(x => (x is IWord ? (x as IWord).ToString().Length : 0) == length)
                        select sentence.ToList().ToString();

    */
            foreach (var sentence in TextResult.Sentences)
            {
             foreach (var sentenceItem in sentence)
                {
                   if ((sentenceItem is IWord) && (sentenceItem.Chars.Length == length))
                    {
                        var curWord = sentenceItem.Chars;
                        Match m = regex.Match(curWord);
                        if (!m.Success)
                        {
                            Console.Write(" {0}", curWord);
                            
                        }
                        else
                        {
                            Console.Write(" <Removed Word \"{0}\">", curWord);
                        }
                    }
                   else
                    {
                        var curSentenceItem = sentenceItem.Chars;
                        if (sentenceItem is IPunctuation)
                        {
                            Console.Write("{0}", curSentenceItem);
                        }
                        else
                        {
                            Console.Write(" {0}", curSentenceItem);
                        }
                    }
              
                }
                Console.WriteLine();
            }
            //foreach (var word in words)
            //{
            //    Console.Write("{0} ", word);
            //}
        }
 // ToDo
        public void ReplaceSubstring (string substr)
        {

        }

    }
}