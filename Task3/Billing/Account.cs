using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class Account
    {
        public Customer Customer { get; protected set; }
        public List<Contract> Contracts = new List<Contract>();
        public List<CallInfoFull> CallsHistory = new List<CallInfoFull>();
        public List<BillingPlan> BillingPlanHistory = new List<BillingPlan>();
    }
}