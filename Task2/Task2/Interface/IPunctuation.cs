using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public interface IPunctuation : ISentenceItem //, IEnumerable<Symbol>
    {
    //    Symbol this[int index] { get; }
     //   int Length { get; }
            Symbol Value { get; }
    }
}
