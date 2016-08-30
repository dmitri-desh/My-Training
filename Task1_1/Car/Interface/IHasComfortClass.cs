using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public interface IHasComfortClass
    {
        ComfortClass ComfortClass { get; }
    }
}