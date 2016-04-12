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
        private List<Ingredient> _ingredients;

        public Salad (string value) // : this(value, new List<Ingredient>())
        {
            this.Name = value;
            _ingredients = new List<Ingredient>();
           
        }
        
        public Salad(string name, ICollection<Ingredient> ingredients)
        {
            Name = name;
            _ingredients = new List<Ingredient>(ingredients);
        }
              
        public Double TotalCalories
        {
            get
            {
                if (_ingredients != null)
                {
                    return _ingredients.Sum(x => x.Calorie/100 * x.Weight);
                }
                else
                {
                    throw new NullReferenceException("Ingredients cannot be null.");
                }
            }
        }
        public void PrintIngredients()
        {
           if (_ingredients != null)
            {
                foreach (var cur in _ingredients)
                {
                    Console.WriteLine(cur.Name.PadRight(16, ' ')
                                               + "\t" + cur.Calorie.ToString("N2").PadLeft(14,' ') 
                                               + "\t" + cur.Weight.ToString("N2").PadLeft(6,' ') 
                                               + "\t" + cur.Proteins.ToString("N2").PadLeft(6,' ')
                                               + "\t" + cur.Fats.ToString("N2").PadLeft(6,' ')
                                               + "\t" + cur.Carbohydrates.ToString("N2").PadLeft(6,' ')
                                     );
                }
            } 
        }

        public void SelectCalorieBetween(double _from, double _to)
        {
            var ingredients = from cur in _ingredients
                              where cur.Calorie >= _from && cur.Calorie <= _to
                              select cur.Name.PadRight(17,' ')+" - "+cur.Calorie.ToString("N2").PadLeft(6,' ');
            Console.WriteLine("От "+_from.ToString("N2")+" до "+_to.ToString("N2")+" ккал содержат:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }
        public void Sort()
        {
            _ingredients.Sort();
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
                return (_ingredients as ICollection<Ingredient>).IsReadOnly;
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