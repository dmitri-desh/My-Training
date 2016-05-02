using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Parser
    {
        private ISentenceItemFactory wordFactory;
        protected ISentenceItemFactory WordFactory
        {
            get { return wordFactory; }
            set { wordFactory = value; }
        }

        private ISentenceItemFactory punctuationFactory;
        protected ISentenceItemFactory PunctuationFactory
        {
            get { return punctuationFactory; }
            set { punctuationFactory = value; }
        }

        private SeparatorContainer separatorContainer;
        protected SeparatorContainer SeparatorContainer
        {
            get { return separatorContainer; }
            set { separatorContainer = value; }
        }
        
        public Text Parse(TextReader reader)
        {
            var orderedSentenceSeparators = SeparatorContainer.SentenceSeparators().OrderByDescending(x => x.Length);
            int bufferLength = 10000;

            string pattern = @"\s+";
            string target = " ";
            Regex regex = new Regex(pattern);

            Text textResult = new Text();
            StringBuilder buffer = new StringBuilder(bufferLength);
            buffer.Clear();
            string currentString = reader.ReadLine();
            currentString = regex.Replace(currentString, target);

            int firstSentenceSeparatorOccurence = -1;
            
            string firstSentenceSeparator;
            buffer.Append(currentString + " ");
            while (currentString != null)
            {
              firstSentenceSeparator = orderedSentenceSeparators.FirstOrDefault(
                            x =>
                            {
                                firstSentenceSeparatorOccurence = buffer.ToString().IndexOf(x);
                                return firstSentenceSeparatorOccurence >= 0;
                            });
           
                    while (firstSentenceSeparator != null)
                    {
                      //  Console.WriteLine("{0}", regex.Replace(buffer.ToString().Substring(0, firstSentenceSeparatorOccurence + firstSentenceSeparator.Length), target));
                        textResult.Sentences.Add(this.ParseSentence(regex.Replace(buffer.ToString().Substring(0, firstSentenceSeparatorOccurence + firstSentenceSeparator.Length), target).TrimStart()));
                        currentString = buffer.ToString().Substring(firstSentenceSeparatorOccurence + firstSentenceSeparator.Length);
                        buffer.Clear();

                        buffer.Append(currentString + " ");

                    firstSentenceSeparator = orderedSentenceSeparators.FirstOrDefault(
                                            x =>
                                            {
                                                firstSentenceSeparatorOccurence = buffer.ToString().IndexOf(x);
                                                return firstSentenceSeparatorOccurence >= 0;
                                            });
                    }

                currentString = reader.ReadLine(); 
                
                buffer.Append(currentString + " ");
            }
            //Console.WriteLine("{0}", regex.Replace(buffer.ToString(), target));
            textResult.Sentences.Add(this.ParseSentence(regex.Replace(buffer.ToString(), target).TrimStart()));
            buffer.Clear();
            return textResult;
        }

        protected ISentence ParseSentence(string source)
        {
            ISentence sentenceResult = new Sentence();

            var orderedSeparators = SeparatorContainer.All().OrderByDescending(x => x.Length);
            var curSource = source;
            string curPunctuation;

            var words = source.Split(orderedSeparators.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < words.Count() - 1; i++)
            {
                sentenceResult.Add(this.ParseSentenceItem(words[i]));
                curSource = curSource.Substring(words[i].Length);
                curPunctuation = curSource.Substring(0, curSource.IndexOf(words[i + 1]));
                if (curPunctuation != " ")
                { 
                   sentenceResult.Add(this.ParseSentenceItem(curPunctuation));
                    
                }
             //   Console.Write("{0}|{1}|", words[i], curPunctuation.Trim());
                curSource = curSource.Substring(curPunctuation.Length);
               
            }
            if (words.Count() > 0)
            {
                sentenceResult.Add(this.ParseSentenceItem(words[words.Count() - 1]));
            }
            if (curSource.Length > 0)
            {
                curPunctuation = curSource.Substring(words[words.Count() - 1].Length);
                sentenceResult.Add(this.ParseSentenceItem(curPunctuation));
             //   Console.WriteLine("{0}|{1}|", words[words.Count() - 1], curPunctuation.Trim());
            }
       
            return sentenceResult; 
        }
        protected ISentenceItem ParseSentenceItem (string source)
        {
            ISentenceItem itemResult = null;
            foreach (var s in SeparatorContainer.All())
            {
                if (source == s.ToString())
                {
                    itemResult = new Punctuation(source);
                    break;
                }
            }
        if (itemResult == null)
            {
                itemResult = new Word(source);
            }
            
            return itemResult;
        }
     
        public Parser(SeparatorContainer separatorContainer)
        {
            this.SeparatorContainer = separatorContainer;
            this.WordFactory = new WordFactory();
            this.PunctuationFactory = new PunctuationFactory(this.SeparatorContainer);
        }
        
    }
}
