using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class OutgoingCallRequest : Request
    {
        public PhoneNumber Target { get; set; }
    }
}