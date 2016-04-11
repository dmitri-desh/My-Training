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
            Salad salad = new Salad("Салат Оливье");
            CustomSaladBuilder builder = new CustomSaladBuilder(salad);
            builder.Build();

            Console.WriteLine("Ингредиент\tКалорийность,ккал\tВес,г\tБелки,г\tЖиры,г\tУглеводы,г");
                
             //   salad.GetEnumerator();
            
            Console.WriteLine("Калорийность "+salad.Name+": "+salad.TotalCalories.ToString());

        }
    }
}
