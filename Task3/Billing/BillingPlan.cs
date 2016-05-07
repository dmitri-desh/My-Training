using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class BillingPlan
    {
        public DateTime LastChange { get; protected set; }
        public BillingType CurBillingType { get; protected set; }
        public decimal Amount { get; protected set; }
        public BillingPlan(BillingType billingType, decimal amount)
        {
            this.LastChange = DateTime.Now;
            this.CurBillingType = billingType;
            this.Amount = amount;
        }
    }
}