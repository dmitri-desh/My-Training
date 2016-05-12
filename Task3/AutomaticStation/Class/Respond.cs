using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticStation
{
    public class Respond
    {
        public Request Request;
        public PhoneNumber Source { get; set; }
        public RespondState State { get; set; }
    }
}