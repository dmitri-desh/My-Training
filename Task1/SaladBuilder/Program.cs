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
            Salad salad = new Salad("Салат Комбинированный");

            CustomSaladBuilder builder = new CustomSaladBuilder(salad);
            builder.Build();

            Console.WriteLine("Ингредиент".PadRight(10, ' ') + "\tКол-во\t"
                               + "Ед.изм.".PadRight(5, ' ') + "\t" + "Вес".PadRight(7, ' ')
                               + "\t" + "Калорийность".PadRight(7, ' ') + "\t" + "Способ нарезки");
            IEnumerable<Item> list = salad.GetItems();

            foreach (Item item in list)
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
            double weight2 = 100;
            IEnumerable<Item> calories = salad.GetCaloriesBetween(weight1, weight2);
            Console.WriteLine("От {0} до {1} ккал. содержат:", weight1, weight2);
            foreach (Item item in calories)
            {
                Console.WriteLine(item.Name.PadRight(17, ' ') + " - " + (item as IHasCalories).Calories.ToString("N2").PadLeft(7, ' '));
            }

            Console.ReadLine();

        }
    }
}
