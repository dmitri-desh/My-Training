using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class AccountRefill
    {
        public DateTime Date { get; protected set; }
        public decimal Amount { get; protected set; }
        public AccountRefill(decimal amount)
        {
            this.Date = DateTime.Now;
            this.Amount = amount;
        }
    }
}