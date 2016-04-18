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
                return ((ICollection<Item>)Items).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Item>)Items).IsReadOnly;
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
                    return Items.Where(t => t is IHasCaloriesAndCarbohydrates).Sum(t => (t as IHasCaloriesAndCarbohydrates).Calories / 100 * t.Weight);
                }

                return 0;
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
            return Items.Where(t => t is IHasCaloriesAndCarbohydrates && (t as IHasCaloriesAndCarbohydrates).Calories >= from && (t as IHasCaloriesAndCarbohydrates).Calories <= to);
        }
        public void SortByWeight()
        {
          // Items = Items.OrderBy(x => x is IHasWeight ? (x as IHasWeight).Weight : 0).ToList();
            Items = Items.OrderBy(x => x.Weight).ToList();
        }

        public void Clear()
        {
            ((ICollection<Item>)Items).Clear();
        }

        public bool Contains(Item item)
        {
            return ((ICollection<Item>)Items).Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            ((ICollection<Item>)Items).CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            return ((ICollection<Item>)Items).Remove(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((ICollection<Item>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Item>)Items).GetEnumerator();
        }
    }   
}