using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Salad : ICollection<Item>
    {
        public string Name;
        private List<Item> _items;

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public Double GetTotalCalories
        {
            get
            {
                if (_items != null)
                {
                    return _items.Where(t => t is IHasCalories).Sum(t => (t as IHasCalories).GetCaloriesCalculated());
                }

                return 0;
            }
        }
        public IEnumerable<Item> GetItems()
        {
            return _items.ToList();
        }

        public IEnumerable<Item> GetCaloriesBetween(double from, double to)
        {
            return _items.Where(t => t is IHasCalories && (t as IHasCalories).Calories >= from && (t as IHasCalories).Calories <= to);
        }
        public void SortByWeight()
        {
           
            _items = _items.OrderBy(x => x is IHasWeight ? (x as IHasWeight).GetWeightCalculated() : 0).ToList();
        }

        public Salad (string name, ICollection<Item> items)
        {
            this.Name = name;
            _items = new List<Item>(items);
        }
        public Salad(string name)
        {
            this.Name = name;
            _items = new List<Item>();
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items.CopyTo(array);
        }

        public bool Remove(Item item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}