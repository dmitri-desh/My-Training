using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomaticStation;

namespace Billing
{
    public class CallInfoFull : CallInfo
    {
        public decimal Amount { get; protected set; }
        public CallInfoFull(PhoneNumber source, PhoneNumber target, DateTime started, TimeSpan duration, decimal amount) : base(source, target, started, duration)
        {
            this.Source = source;
            this.Target = target;
            this.Started = started;
            this.Duration = duration;
            this.Amount = amount;
        }
        public new PhoneNumber Source { get; protected set; }
        public new PhoneNumber Target { get; protected set; }
        public new DateTime Started { get; protected set; }
        public new TimeSpan Duration { get; protected set; }
    }
}