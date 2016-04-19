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
          //  ICollection<Item> ingredients = new List<Item>();

            Salad salad = new Salad("Салат Тест");

            CustomSaladBuilder builder = new CustomSaladBuilder(salad);
            builder.Build();
            
            Console.WriteLine("Ингредиент".PadRight(16, ' ') + "\tКалорийн.,ккал\t"
                               + "Вес,г".PadRight(7, ' ') + "\t" + "Белки,г".PadRight(7, ' ')
                               + "\t" + "Жиры,г".PadRight(7, ' ') + "\t" + "Углеводы,г");
           /* salad.PrintIngredients();
            
            Console.WriteLine();
            Console.WriteLine("Калорийность {0}: {1} ккал", salad.Name, salad.GetTotalCalories.ToString("N3"));
            Console.WriteLine();
            /*
            Console.WriteLine("Сортировка по весу:");
            salad.Sort();
            salad.PrintIngredients();

            Console.WriteLine();
            salad.SelectCalorieBetween(2, 150);
            */
            
            IEnumerable<Item> list = salad.GetItems();

            foreach(Item item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Калорийность " + salad.Name + ": " + salad.GetTotalCalories.ToString("N3") + " ккал.");
            Console.WriteLine();

            Console.WriteLine("Сортировка по весу:");
            salad.SortByWeight();
            IEnumerable<Item> list1 = salad.GetItems();
            foreach (Item item in list1)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            double weight1 = 2;
            double weight2 = 150;
            IEnumerable<Item> calories = salad.GetCalorieBetween(weight1, weight2);
            Console.WriteLine("От {0} до {1} ккал. содержат:", weight1, weight2);
            foreach(Item item in calories)
            {
                Console.WriteLine(item.Name.PadRight(17, ' ') + " - " + (item as IHasCalories).Calories.ToString("N2").PadLeft(7, ' '));
            }

            Console.ReadLine();
        }

    }
}
