using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticStation
{
    public abstract class Request
    {
        public PhoneNumber Source { get; set; }
    }
}