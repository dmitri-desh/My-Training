using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class TestTerminal : Terminal
    {
        public TestTerminal(PhoneNumber number) : base(number)
        {
            this.IncomingRequest += this.OnIncomingRequest;
            this.Online += (sender, args) => { Console.WriteLine("Terminal {0} turned to online mode", Number); };
            this.Offline += (sender, args) => { Console.WriteLine("Terminal {0} turned to offline mode", Number); };
        }

        public void OnIncomingRequest(object sender, IncomingCallRequest request)
        {
            Console.WriteLine("{0} received request for incoming connection from {1}", this.Number, request.Source);
        }

    }
}