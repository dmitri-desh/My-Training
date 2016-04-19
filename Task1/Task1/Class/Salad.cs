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
        private List<Item> Items;

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public Salad(string value) // : this(value, new List<Ingredient>())
        {
            this.Name = value;
            Items = new List<Item>();

        }

        public Salad(string name, ICollection<Item> items)
        {
            Name = name;
            Items = new List<Item>(items);
        }

        public Double GetTotalCalories
        {
            get
            {
                if (Items != null)
                {
                    return Items.Where(t => t is IHasCalories).Sum(t => (t as IHasCalories).Calories / 100 * t.Weight);
                }

                return 0;
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
            if (item != null)
            {
                Items.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
       
        public IEnumerable<Item> GetItems()
        {
            return Items.ToList();
        }

        public IEnumerable<Item> GetCalorieBetween(double from, double to)
        {
            return Items.Where(t => t is IHasCalories && (t as IHasCalories).Calories >= from && (t as IHasCalories).Calories <= to);
        }
        public void SortByWeight()
        {
          // Items = Items.OrderBy(x => x is IHasWeight ? (x as IHasWeight).Weight : 0).ToList();
            Items = Items.OrderBy(x => x.Weight).ToList();
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(Item item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            return Items.Remove(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }   
}