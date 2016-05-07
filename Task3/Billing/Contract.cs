using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3;

namespace Billing
{
    public class Contract
    {
        public string ContractNumber { get; protected set; }
        public DateTime Date { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime ExpirationDate { get; protected set; }
        public PhoneNumber PhoneNumber { get; protected set; }
        public BillingPlan CurBillingPlan { get; protected set; }
        public List<BillingPlan> BillingPlanHistory = new List<BillingPlan>();
        public List<CallInfoFull> CallsHistory = new List<CallInfoFull>();
        public Contract(string name, DateTime expirationDate, PhoneNumber phoneNumber, BillingPlan billingPlan)
        {
            this.ContractNumber = name;
            this.Date = DateTime.Now;
            this.StartDate = DateTime.Now;
            this.ExpirationDate = expirationDate;
            this.PhoneNumber = phoneNumber;
            this.CurBillingPlan = billingPlan;
        }

    }
}