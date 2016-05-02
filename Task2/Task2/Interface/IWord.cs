using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public interface IWord: ISentenceItem, IEnumerable<Symbol>
    {
        Symbol this[int index] { get; }
        int Length { get; }
    }
}
