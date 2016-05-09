using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticStation
{
    public class CallInfo
    {
        public PhoneNumber Source { get; set; }
        public PhoneNumber Target { get; set; }
        public DateTime Started { get; set; }
        public TimeSpan Duration { get; set; }
        public CallInfo ()
        { }
        public CallInfo(PhoneNumber source, PhoneNumber target, DateTime started, TimeSpan duration)
        {
            this.Source = source;
            this.Target = target;
            this.Started = started;
            this.Duration = duration;
        }
    }
}