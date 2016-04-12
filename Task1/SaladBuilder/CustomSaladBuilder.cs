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
            _salad.Add(new Ingredient()
            {
                Name = "Огурец солёный",
                Calorie = 11,
                Weight = 200,
                Proteins = 0.8,
                Fats = 0.1,
                Carbohydrates = 1.7
            }
                      );
            _salad.Add(new Ingredient()
            {
                Name = "Говядина варёная",
                Calorie = 254,
                Weight = 100,
                Proteins = 25.8,
                Fats = 16.8,
                Carbohydrates = 0
            }
                      );
            _salad.Add(new Ingredient()
            {
                Name = "Яйцо куриное",
                Calorie = 147.58,
                Weight = 94,
                Proteins = 11.94,
                Fats = 10.25,
                Carbohydrates = 0.66
            }
                       );
            _salad.Add(new Ingredient()
            {
                Name = "Картофель варёный",
                Calorie = 82,
                Weight = 100,
                Proteins = 2,
                Fats = 0.4,
                Carbohydrates = 16.7
            }
                      );
            _salad.Add(new Ingredient()
            {
                Name = "Горошек зелёный",
                Calorie = 55,
                Weight = 100,
                Proteins = 3.6,
                Fats = 0.1,
                Carbohydrates = 9.8
            }
                      );
            _salad.Add(new Ingredient()
            {
                Name = "Морковь варёная",
                Calorie = 12.5,
                Weight = 50,
                Proteins = 0.4,
                Fats = 0.15,
                Carbohydrates = 2.5
            }
                      );
            _salad.Add(new Ingredient()
            {
                Name = "Лук репчатый",
                Calorie = 30.75,
                Weight = 75,
                Proteins = 1.05,
                Fats = 0,
                Carbohydrates = 7.8
            }
           );
            _salad.Add(new Ingredient()
            {
                Name = "Майонез столовый",
                Calorie = 501.6,
                Weight = 80,
                Proteins = 1.92,
                Fats = 53.6,
                Carbohydrates = 3.12
            }
           );
        }
    }
}
