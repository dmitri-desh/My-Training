using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticStation
{
    public class OutgoingCallRequest : Request
    {
        public PhoneNumber Target { get; set; }
    }
}