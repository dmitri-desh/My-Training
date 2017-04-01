// Copyright © Microsoft Corporation.  All Rights Reserved.
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
    }
}
