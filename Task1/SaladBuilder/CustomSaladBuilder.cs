using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace SaladBuilder
{
    public partial class CustomSaladBuilder
    {
        private Salad _salad;
        public CustomSaladBuilder(Salad salad)
        {
            _salad = salad;
        }
        public void Build()
        {
            AddIngredients();
        }
        protected void AddIngredients()
        {
            _salad.Add(new Fish("Карась", 1, Measures.Pcs, 600, 250));
            _salad.Add(new Fish("Осьминог", 200, 150));
            _salad.Add(new Vegetable("Морковь", 2, Measures.Pcs, 60, 20));
            _salad.Add(new Vegetable("Картофель", 3, Measures.Pcs, 50, 50, CuttingMethods.Dicing));
            _salad.Add(new Meat("Говядина", 300, 100));
            _salad.Add(new Spice("Соль"));
            _salad.Add(new Spice("Перец", 2, Measures.Pinch));
            _salad.Add(new Fruit("Яблоко", 1, Measures.Pcs, 20));
            _salad.Add(new Fruit("Слива", 2, Measures.Pcs, 20, 40));
        }
    }

}
