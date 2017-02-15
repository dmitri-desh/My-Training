using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.CreditCard
{
    class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public OperationType OperType { get; set; }
        public Transaction(int id, decimal amount, OperationType operType)
        {
            Id = id;
            Amount = amount;
            OperType = operType;
        }
        public override string ToString()
        {
            return Id + " " + Amount + " " + OperType;
        }
    }
}
