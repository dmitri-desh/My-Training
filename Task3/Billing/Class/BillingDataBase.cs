using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class BillingDataBase 
    {
        public ICollection<Account> Accounts { get; set; }
        public BillingDataBase()
        {
            Accounts = new List<Account>();
        }
    }
}