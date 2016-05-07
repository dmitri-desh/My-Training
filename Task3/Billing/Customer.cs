using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class Customer
    {
        public string Name { get; protected set; }
        public Customer(string name)
        {
            this.Name = name;
        }
    }
}