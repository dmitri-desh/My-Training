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
        
        public ICollection<Contract> Contracts { get; set; }
        public decimal Amount { get; protected set; }

        public ICollection<AccountRefill> AccountRefillLog { get; set; }
        public Account(int accountId, Customer customer)
        {
            this.AccountId = accountId;
            this.Contracts = new List<Contract>();
            this.Customer = customer;
            this.Amount = 0;
            this.AccountRefillLog = new List<AccountRefill>();
        }

        public Account()
        {
        }
        public void FillAccount(decimal amount)
        {
            if (amount > 0)
            this.Amount += amount;
            this.AccountRefillLog.Add(new AccountRefill(amount));
        }
        public override string ToString()
        {
            return this.Customer.Name +" Баланс: "+ this.Amount.ToString();
                //base.ToString();
        }
    }
}