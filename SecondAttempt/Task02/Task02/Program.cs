using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.API;
using Task02.Keys;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            try
            {
                // Task02 Calculation.cs
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}-ое число Фибоначчи = {1}", i, Calculation.GetFibonacci(i));
                Console.WriteLine("{0}! = {1}", i, Calculation.GetFactorial(i));

                // Task02 ObjCounter.cs
                ObjCounter obj1 = new ObjCounter();
                ObjCounter obj2 = new ObjCounter();
                ObjCounter obj3 = new ObjCounter();
                ObjCounter obj4 = new ObjCounter();
                ObjCounter obj5 = new ObjCounter();
                ObjCounter obj6 = new ObjCounter();
                obj1.Dispose();
                obj3.Dispose();
                Console.WriteLine("Образовано {0} объектов класса", obj1.GetObjectsCount());

                // Task02  Order.cs; example of Nested Class
                Order order = new Order();
                order.AddOrderLine("Огурец", 5, 0.43);
                order.AddOrderLine("Помидор", 3, 0.51);
                order.AddOrderLine("Картофель", 10, 0.10);
                Console.WriteLine("Заказ:");
                Console.WriteLine("Наименование".PadRight(10)
                       + "\tКол-во".PadRight(3)
                       + "\tЦена".PadRight(5)
                       + "\tСтоимость".PadRight(5));
                order.GetOrder();
                Console.WriteLine("Общая стоимость заказа: {0:C2}", order.GetOrderTotal());

                // Task02.Keys CommonKey.cs
                KeyMetal keyMetal = new KeyMetal("Стальной ключ", KeyType.Metal);
                keyMetal.UseKey();

                KeyMagnetic keyMagnetic = new KeyMagnetic("Магнитная карта", KeyType.Magnetic, "345345345rtertwetwetpupkin");
                if (keyMagnetic.CheckLogin("popkin1234")) keyMagnetic.UseKey();
                if (keyMagnetic.CheckLogin("345345345rtertwetwetpupkin")) keyMagnetic.UseKey();

                KeyContactless keyContactless = new KeyContactless("Бесконтактный ключ", KeyType.Contactless, "jghsdsdfg6sd86g8sd6g8sd6g87s6df8g76sdf87g", 4321);
                if (keyContactless.CheckPin("jhg34jg53j4g5j3g5jh34g5j34j5hg", 2342)) keyContactless.UseKey();
                if (keyContactless.CheckPin("jghsdsdfg6sd86g8sd6g8sd6g87s6df8g76sdf87g", 4321)) keyContactless.UseKey();

                // Task02.API Card.cs
                Card card = new Card("Моя корзина");
                card.Add(new Item("Фигня1", 34.11m, 14));
                card.Add(new Item("Фигня2", 23.54m, 18));
                card.Add(new Item("Фигня3", 2.11m, 5));
                card.Add(new Item("Фигня4", 3.61m, 7));
                card.Add(new Item("Фигня5", 9.01m, 3));
                card.Add(new Item("Фигня6", 4.21m, 6));

                Console.WriteLine("{0}", card.ToString());
                IEnumerable<Item> items = card.GetItems();
                foreach (Item item in items)
                {
                    Console.WriteLine(item.ToString());
                }
                
                Console.WriteLine("Удаляем элемент");
                card.Remove(new Item("Фигня3", 2.11m, 5));
                items = card.GetItems();
                foreach (Item item in items)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Итоговая сумма:                 {0}", card.GetTotal());
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректное число");
            }

        }
    }
}
