using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class SentenceItemFactory : ISentenceItemFactory
    {
        private ISentenceItemFactory punctuationFactory;
        private ISentenceItemFactory wordFactory;
        private ISentenceItem _result;
        
        public ISentenceItem Create(string chars)
        {
            ISentenceItem result = punctuationFactory.Create(chars);
            if (result == null)
            {
                result = wordFactory.Create(chars);
            }
            _result = result;
            return result;
        }
        public SentenceItemFactory(string source)
        {
           
        }
        public SentenceItemFactory(ISentenceItemFactory punctuationFactory, ISentenceItemFactory wordFactory)
        {
            this.punctuationFactory = punctuationFactory;
            this.wordFactory = wordFactory;
        }
        public override string ToString()
        {
            return _result.ToString();
        }
    }
}
