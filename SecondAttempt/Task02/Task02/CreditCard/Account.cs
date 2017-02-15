using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.CreditCard
{
    //6. Напишите класс для работы с транзакциями по банковской карте. Минимальный функционал должен содержать: список проведенных транзакций,
    //   максимальная и минимальная транзакция из проведенных. Обоснуйте архитектуру.
    class Account : ICollection<Transaction>
    {
        public string Name;
        public string AccNumber;
        public decimal Amount;
        private List<Transaction> _transactions = new List<Transaction>();

        public Account (string name, string accNumber)
        {
            Name = name;
            AccNumber = accNumber;
            Amount = 0;
        }
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
            Amount =  Amount + (item.OperType == OperationType.Refill ? item.Amount : -item.Amount) ; 
            
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
        public Transaction GetMinTransaction ()
        {
            IEnumerable<Transaction> items = _transactions.OrderBy(t => t.Amount);
            return items.First();
        }
        public Transaction GetMaxTransaction()
        {
            IEnumerable<Transaction> items = _transactions.OrderByDescending(t => t.Amount);
            return items.First();
        }
    }
}
