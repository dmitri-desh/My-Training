using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class Sentence : ISentence
    {
        private ICollection<ISentenceItem> items = new List<ISentenceItem>();
    
        public Sentence()
        {
           
        }

        public Sentence(ICollection<ISentenceItem> source) 
        {
            items = source;
          
        }
        
        public void Add(ISentenceItem item)
        {
            if (item != null)
            {
                items.Add(item);
            }
            else
            {
                throw new NullReferenceException("Item not exists!");
            }
        }

        public bool Remove(ISentenceItem item)
        {
            return items.Remove(item);
            //throw new NotImplementedException();
        }

        public int Count
        {
            get {
                return items.Count;
                //throw new NotImplementedException();
                }
        }

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return items.GetEnumerator();
            //throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
            //throw new NotImplementedException();
        }

    }
}
