using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomaticStation;

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
        public ICollection<BillingPlan> BillingPlanLog { get; protected set; }
        public ICollection<CallInfoFull> CallsLog { get; protected set; }
        public Contract(string name, PhoneNumber phoneNumber, BillingPlan billingPlan)
        {
            this.ContractNumber = name;
            this.Date = DateTime.Now;
            this.StartDate = DateTime.Now;
            this.PhoneNumber = phoneNumber;
            this.CurBillingPlan = billingPlan;
            this.BillingPlanLog = new List<BillingPlan>();
            this.CallsLog = new List<CallInfoFull>();
        }
        public bool ChangeBillingPlan(BillingType billingType, decimal amount)
        {
            if (amount >= 0)
            {
                if (this.CurBillingPlan == null)
                {
                    this.CurBillingPlan = new BillingPlan(billingType, amount);
                    this.BillingPlanLog.Add(this.CurBillingPlan);
                    return true;
                }
                else if (this.CurBillingPlan != null && this.CurBillingPlan.LastChange <= DateTime.Now.AddMonths(-1))
                {
                    this.CurBillingPlan = new BillingPlan(billingType, amount);
                    this.BillingPlanLog.Add(this.CurBillingPlan);
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public void AddCallToLog(CallInfo callInfo)
        {
            if (callInfo !=null)
            {
               var callInfoFull = new CallInfoFull(callInfo, this.CurBillingPlan.CalculateAmount(callInfo.Duration));
               this.CallsLog.Add(callInfoFull);
            }
        }
    }
}