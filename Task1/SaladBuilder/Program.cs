using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace SaladBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<Ingredient> ingredients = new List<Ingredient>();

            Salad salad = new Salad("Салат Оливье", ingredients);

            CustomSaladBuilder builder = new CustomSaladBuilder(salad);
            builder.Build();

            Console.WriteLine("Ингредиент".PadRight(16, ' ')+"\tКалорийн.,ккал\t"
                               +"Вес,г".PadRight(7, ' ')+"\t"+"Белки,г".PadRight(7,' ')
                               +"\t"+"Жиры,г".PadRight(7,' ')+"\t"+"Углеводы,г");
            salad.PrintIngredients();
            Console.WriteLine();
            Console.WriteLine("Калорийность {0}: {1} ккал", salad.Name, salad.TotalCalories.ToString("N3"));
            Console.WriteLine();

            Console.WriteLine("Сортировка по весу:");
            salad.Sort();
            salad.PrintIngredients();

            Console.WriteLine();
            salad.SelectCalorieBetween(2,150);

            Console.ReadLine();
        }
    }
}
