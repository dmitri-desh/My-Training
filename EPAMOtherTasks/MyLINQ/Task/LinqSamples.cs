﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;
using System.Globalization;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Where - Example 1")]
		[Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
		public void Linq1()
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var lowNums =
				from num in numbers
				where num < 5
				select num;

			Console.WriteLine("Numbers < 5:");
			foreach (var x in lowNums)
			{
				Console.WriteLine(x);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Example 2")]
		[Description("This sample return return all presented in market products")]
		public void Linq2()
		{
			var products =
				from p in dataSource.Products
				where p.UnitsInStock > 0
				select p;

			foreach (var p in products)
			{
				ObjectDumper.Write(p);
			}
		}
        [Category("My Tasks")]
        [Title("Where - My Task 1")]
        [Description("1. Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X. " + 
                     "Продемонстрируйте выполнение запроса с различными X (подумайте, можно ли обойтись без копирования запроса несколько раз)")]
        public void Linq3()
        {
            decimal X =  10000M;
            var customersList =
                from customers in dataSource.Customers
                from orders in customers.Orders
                group orders by customers.CompanyName into customerGroup
                let sumTotal = customerGroup.Sum(t => t.Total)
                where sumTotal > X
                select new {CompanyName = customerGroup.Key, sumTotal };

            ObjectDumper.Write("Customers with Sum Total > " + X);
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 2")]
        [Description("2. Для каждого клиента составьте список поставщиков, находящихся в той же стране и том же городе. " + 
                     "Сделайте задания с использованием группировки и без.")]
        public void Linq4()
        {
            var customersList =
                from customers in dataSource.Customers
                from suppliers in dataSource.Suppliers
                where customers.Country == suppliers.Country && customers.City == suppliers.City
                select new {customers.CompanyName, customers.Country, customers.City, suppliers.SupplierName };

            ObjectDumper.Write("Customers and Suppliers with equals City & Country (without grouping):");
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
            ObjectDumper.Write("Customers and Suppliers with equals City & Country (with join):");
            customersList =
               from customers in dataSource.Customers
               join suppliers in dataSource.Suppliers on new { customers.Country, customers.City} equals new {suppliers.Country, suppliers.City}
               select new { customers.CompanyName, customers.Country, customers.City, suppliers.SupplierName };
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 3")]
        [Description("3. Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X ")]
        public void Linq5()
        {
            decimal X = 1000M;

            var customersList = (
                from customers in dataSource.Customers
                from orders in customers.Orders
                where orders.Total > X
                select new { customers.CompanyName}).Distinct();

            ObjectDumper.Write("Customers with Orders with Totals > " + X);
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 4")]
        [Description("4. Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами " +
                     "(принять за таковые месяц и год самого первого заказа)")]
        public void Linq6()
        {
           var customersList =
                from customers in dataSource.Customers
                from orders in customers.Orders
                group orders by customers.CompanyName into customerGroup
                let minOrderDate = customerGroup.Min(d => d.OrderDate)
                select new { CompanyName = customerGroup.Key, minOrderDate.Month, minOrderDate.Year };

            ObjectDumper.Write("Customers with Orders");
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 5")]
        [Description("5. Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу, оборотам клиента " +
                        "(от максимального к минимальному) и имени клиента")]
        public void Linq7()
        {
            var customersList = (
                 from customers in dataSource.Customers
                 from orders in customers.Orders
                 group orders by customers.CompanyName into customerGroup
                 let minOrderDate = customerGroup.Min(d => d.OrderDate)
                 let sumTotal = customerGroup.Sum(t => t.Total)
                 select new { minOrderDate.Year, minOrderDate.Month, sumTotal, CompanyName = customerGroup.Key})
                 .OrderBy(year => year.Year)
                 .ThenBy(month => month.Month)
                 .ThenByDescending(total => total.sumTotal)
                 .ThenBy(name => name.CompanyName);

            ObjectDumper.Write("Customers with Orders");
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 6")]
        [Description("6. Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора" + 
                     "(для простоты считаем, что это равнозначно «нет круглых скобочек в начале»).")]
        public void Linq8()
        {
            var customersList = 
                 from customers in dataSource.Customers
                 where customers.PostalCode == null || ( !customers.PostalCode.All(char.IsDigit) 
                                                         || customers.Region == null 
                                                         || customers.Phone.ToArray()[0] != '('
                                                        )
                 select new { customers.CompanyName, customers.PostalCode, customers.Region, customers.Phone };

            ObjectDumper.Write("Customers with Orders");
            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 1);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 7")]
        [Description("7. Сгруппируйте все продукты по категориям, внутри – по наличию на складе, внутри последней группы отсортируйте по стоимости")]
        public void Linq9()
        {
            var productsList =
                 from products in dataSource.Products
<<<<<<< HEAD
                 group products by products.Category into categoryGroup
                 select new { ProdCategory = categoryGroup.Key,
                                     Prods = 
                                            from cG in categoryGroup
                                            select new {cG.ProductName}

                            };

            ObjectDumper.Write("Products");
            foreach (var p in productsList)
            {
                ObjectDumper.Write(p, 1);
=======
                 group products by products.Category into categGroup
                 select new { Category = categGroup.Key,
                                 Stock = 
                                        from inStock in categGroup
                                        orderby inStock.UnitPrice
                                        group inStock by (inStock.UnitsInStock == 0 ? "OutOfStock" : "InStock") into inStockGroup
                                        select new {Stock = inStockGroup.Key, 
                                                    //inStockGroup
                                                    Prods =
                                                            from prods in inStockGroup
                                                            select new { prods.ProductID, prods.ProductName, prods.UnitPrice}
                                                   }
                             };

            ObjectDumper.Write("Products");
            foreach (var c in productsList)
            {
                ObjectDumper.Write(c, 2);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 8")]
        [Description("8. Сгруппируйте товары по группам «дешевые», «средняя цена», «дорогие». Границы каждой группы задайте сами")]
        public void Linq10()
        {
            var limBottom = 10.0000M;
            var limTop    = 40.0000M;

            var productsList = (
                 from products in dataSource.Products
                 let range = (products.UnitPrice <= limBottom ? 1 : 
                              products.UnitPrice > limBottom && products.UnitPrice <= limTop ? 2 :
                              3
                             )
                 group products by range into priceGroup
                 select new { Price = priceGroup.Key == 1 ? "Cheap" : priceGroup.Key == 2 ? "Average" : "Expensive", priceGroup})
                 .OrderBy(p => p.priceGroup.Key)
                 ;

            ObjectDumper.Write("Products");
            foreach (var c in productsList)
            {
                ObjectDumper.Write(c, 2);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 9")]
        [Description("9. Рассчитайте среднюю прибыльность каждого города (среднюю сумму заказа по всем клиентам из данного города)" +
                       " и среднюю интенсивность (среднее количество заказов, приходящееся на клиента из каждого города)")]
        public void Linq11()
        {
            var customersList = 
                from customers in dataSource.Customers
                group customers by customers.City into cityGroup
                let avgSumTotal = cityGroup.Average(o => o.Orders.Sum(t => t.Total))
                let avgCntOrders = cityGroup.Average(o => o.Orders.Count()) / cityGroup.Count()
                select new
                {
                   City = cityGroup.Key,
                   avgSumTotal,
                   avgCntOrders
                }
                ;
                
           foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 2);
            }
        }

        [Category("My Tasks")]
        [Title("Where - My Task 10")]
        [Description("10. Сделайте среднегодовую статистику активности клиентов по месяцам (без учета года), статистику по годам, по годам и месяцам" + 
                     "    (т.е. когда один месяц в разные годы имеет своё значение).")]
        public void Linq12()
        {
            var customersList =
               from customers in dataSource.Customers
               group customers by customers.CompanyName into custGroup
               select new
               {
               Customer = custGroup.Key,
               OrdersMonths =
                        from orders in custGroup
                        select new
                        { 
                            Month = 
                            from months in orders.Orders
                            orderby months.OrderDate.Month
                            group months by months.OrderDate.ToString("MMMM", CultureInfo.CurrentCulture) into monthGroup
                            let avgMonthTotal = monthGroup.Average(t => t.Total)
                            select new
                            {
                               Month = monthGroup.Key,
                               avgMonthTotal
                            }
                        },
                   OrderYears = 
                           from orders in custGroup
                           select new
                           {
                               Year = 
                                        from years in orders.Orders
                                        orderby years.OrderDate.Year
                                        group years by years.OrderDate.Year into yearGroup
                                        let avgYearTotal = yearGroup.Average(t => t.Total)
                                        select new
                                        {
                                            Year = yearGroup.Key,
                                            avgYearTotal
                                        }
                           },
                   OrderMonthsYears =
                           from orders in custGroup
                           select new
                           {
                               MonthYear =
                                        from monthsYears in orders.Orders
                                        orderby monthsYears.OrderDate.Year, monthsYears.OrderDate.Month
                                        group monthsYears by monthsYears.OrderDate.ToString("MMMM yyyy", CultureInfo.CurrentCulture) into monthYearGroup
                                        let avgMonthYearTotal = monthYearGroup.Average(t => t.Total)
                                        select new
                                        {
                                            MonthYear = monthYearGroup.Key,
                                            avgMonthYearTotal
                                        }
                           }
               }
               ;

            foreach (var c in customersList)
            {
                ObjectDumper.Write(c, 3);
>>>>>>> origin/New
            }
        }
    }
}
