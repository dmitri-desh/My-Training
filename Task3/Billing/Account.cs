using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class Account
    {
        public int AccountId { get; protected set; }
        public Customer Customer { get; protected set; }
        public List<Contract> Contracts = new List<Contract>();
        public decimal Amount { get; protected set; }

        public List<AccountRefill> AccountRefillHistory = new List<AccountRefill>();
        public Account(int accountId)
        {
            this.AccountId = accountId;
        }
    }
}