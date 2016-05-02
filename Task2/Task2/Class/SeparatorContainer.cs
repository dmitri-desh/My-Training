using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class SeparatorContainer
    {
        private string[] sentenceSeparators = new string[] { "?", "!", "...", "?!", "? ", ". ", "! "};
        private string[] wordSeparators = new string[]{",", " ", ", ", " - ", " (", ") ", "; ", Environment.NewLine};

        public IEnumerable<string> SentenceSeparators()
        {
            return sentenceSeparators.AsEnumerable();
        }

        public IEnumerable<string> WordSeparators()
        {
            return wordSeparators.AsEnumerable();
        }

        public IEnumerable<string> All()
        {
            return sentenceSeparators.Concat(WordSeparators());
        }
    }
}
