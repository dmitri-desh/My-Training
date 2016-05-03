using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public interface ISentence : IEnumerable<ISentenceItem>
    {
        void Add(ISentenceItem item);
        bool Remove(ISentenceItem item);
        int Count { get; }
    } 
}
