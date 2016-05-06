using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Respond
    {
        public Request Request;
        public PhoneNumber Source { get; set; }
        public RespondState State { get; set; }
    }
}