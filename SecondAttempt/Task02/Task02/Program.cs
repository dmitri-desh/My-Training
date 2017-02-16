using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.API;
using Task02.CreditCard;
using Task02.Keys;
using Task02.Shape;

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
                Cart card = new Cart("Моя корзина");
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

                // Task02.CreditCard
                Account account = new Account("Пупкин", "0000001");
                account.Add(new Transaction(1, 1000m, OperationType.Refill));
                account.Add(new Transaction(2, 500.60m, OperationType.Refill));
                account.Add(new Transaction(3, 301m, OperationType.Refill));
                account.Add(new Transaction(4, 101.34m, OperationType.Withdraw));
                account.Add(new Transaction(5, 2301.1m, OperationType.Refill));
                account.Add(new Transaction(6, 43.24m, OperationType.Withdraw));
                account.Add(new Transaction(7, 671.32m, OperationType.Refill));
                account.Add(new Transaction(8, 130m, OperationType.Refill));
                account.Add(new Transaction(9, 678.9m, OperationType.Refill));
                account.Add(new Transaction(10, 301.25m, OperationType.Withdraw));
                account.Add(new Transaction(11, 125.47m, OperationType.Refill));

                Console.WriteLine("Список транзакций:");
                foreach (Transaction item in account.GetItems())
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("Баланс счёта {0} : {1}", account.AccNumber, account.Amount);
                Console.WriteLine("Минимальная транзакция: {0}", account.GetMinTransaction());
                Console.WriteLine("Максимальная транзакция: {0}", account.GetMaxTransaction());

                // Task02.Shape
                List<Shape.Shape> shapes = new List<Shape.Shape>();
                shapes.Add(new Circle(0, 0, 25));
                shapes.Add(new Rectangle(5, 5, 11, 20));
                shapes.Add(new Triangle(10, 10));
                foreach (Shape.Shape shape in shapes)
                {
                    shape.Draw();
                    Console.WriteLine("Area: {0}", shape.GetArea());
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректное число");
            }

        }
    }
}
