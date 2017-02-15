using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.CreditCard
{
    class Account : ICollection<Transaction>
    {
        public string Name;
        public string Surname;
        public string AccNumber;
        public decimal Amount;
        private List<Transaction> _transactions = new List<Transaction>();
        public int Count
        {
            get
            {
                return _transactions.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Transaction item)
        {
            if (_transactions != null) _transactions.Add(item);
        }

        public void Clear()
        {
            _transactions.Clear();
        }

        public bool Contains(Transaction item)
        {
           return _transactions.Contains(item);
        }

        public void CopyTo(Transaction[] array, int arrayIndex)
        {
            _transactions.CopyTo(array);
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return _transactions.GetEnumerator();
        }

        public bool Remove(Transaction item)
        {
            return _transactions.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _transactions.GetEnumerator();
        }
        public IEnumerable<Transaction> GetItems()
        {
            return _transactions.ToList();
        }
        public override string ToString()
        {
            return AccNumber + " " + Amount;
        }
    }
}
