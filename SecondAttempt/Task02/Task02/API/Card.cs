using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.API
{           //5.	Напишите простейший API для работы с корзиной интернет-магазина. Доступны следующие операции: добавление товара, удаление товара, подсчет общей суммы заказа.
    class Card : ICollection<Item>
    {
        private List<Item> _order;

        public string Id;

        public Card (string id)
        {
           Id = id;
            _order = new List<Item>();
        }
        public decimal GetTotal ()
        {
            return _order.Sum(t => t.GetAmount());
        }

        public int Count
        {
            get
            {
                return _order.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public void Add(Item item)
        {
            if (_order != null) _order.Add(item);
        }

        public void Clear()
        {
            _order.Clear();
        }

        public bool Contains(Item item)
        {
           return _order.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _order.CopyTo(array);
        }

        public bool Remove(Item item)
        {
           return _order.Remove(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _order.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _order.GetEnumerator();
        }
        public IEnumerable<Item> GetItems()
        {
            return _order.ToList();
        }
        public override string ToString()
        {
            return Id;
        }
    }
}
