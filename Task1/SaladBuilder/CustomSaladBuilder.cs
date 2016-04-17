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
          
            _salad.Add(new Salt("Соль", 15));
            _salad.Add(new Sugar("Сахар", 25, 398, 99.7));
            _salad.Add(new Ingredient("Огурец солёный", 200, 11, 1.7, 0.8, 0.1));
            _salad.Add(new Ingredient("Яйцо куриное", 94, 147.58, 0.66, 11.94, 10.25));
            _salad.Add(new Ingredient("Картофель варёный", 100, 82, 16.7, 2, 0.4));
            _salad.Add(new Ingredient("Горошек зелёный", 100, 55, 9.8, 3.6, 0.1));
            _salad.Add(new Ingredient("Морковь варёная", 50, 12.5, 2.5, 0.4, 0.15));
            _salad.Add(new Ingredient("Майонез столовый", 80, 501.6, 3.12, 1.92, 53.6));
          }
    }
}
