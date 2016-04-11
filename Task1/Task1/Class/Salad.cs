using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class Salad : ICollection<Ingredient>
    {
        public string Name;
        private ICollection<Ingredient> _ingredients;

        public Salad (string v)
        {
            this.Name = v;
        }
        
        public Salad(string name,ICollection<Ingredient> ingredients)
        {
            Name = name;
            _ingredients = ingredients;
        }
              
        public Double TotalCalories
        {
            get
            {
                if (_ingredients != null)
                {
                    return _ingredients.Sum(x => x.Calorie * x.Weight);
                }
                else
                {
                    throw new NullReferenceException("Ingredients cannot be null.");
                }
            }
        }

        public int Count
        {
            get
            {
                return _ingredients.Count;
                //throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _ingredients.IsReadOnly;
                //throw new NotImplementedException();
            }
        }

        public void Add(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                _ingredients.Add(ingredient);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            if (_ingredients.Count > 0)
            {
                _ingredients.Clear();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Contains(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                return _ingredients.Contains(ingredient);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Ingredient[] array, int arrayIndex)
        {
            if (array != null)
            {
                _ingredients.CopyTo(array, arrayIndex);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<Ingredient> GetEnumerator()
        {
            return _ingredients.GetEnumerator();
            //throw new NotImplementedException();
        }

        public bool Remove(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                return _ingredients.Remove(ingredient);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
            //throw new NotImplementedException();
        }
    }
}