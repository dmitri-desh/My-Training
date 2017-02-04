using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.API
{
    class Card : ICollection<Item>
    {
        protected List<Item> _order;

        public string Id;

        public int Count
        {
            get
            {
                return _order.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
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
            throw new NotImplementedException();
        }

        public bool Remove(Item item)
        {
           return _order.Remove(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _order;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
