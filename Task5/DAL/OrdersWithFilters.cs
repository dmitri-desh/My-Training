using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdersWithFilters
    {
        private static ICollection<Model.Order> orderList = new List<Model.Order>();
        private static ICollection<Model.Manager> managerList = new List<Model.Manager>();
        private static ICollection<Model.Product> productList = new List<Model.Product>();
        private static ICollection<Model.Customer> customerList = new List<Model.Customer>();
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public IEnumerable<Model.Order> GetOrders(DateTime from, DateTime to, double managerId, double customerId, double productId)
        {
            var items = new OrderRepository().GetAll().ToList();
            var curList = new List<Model.Order>();
            if (from != null && to != null)
            {
                foreach (var item in items)
                {
                    if (item.PurchaseDate <= from && item.PurchaseDate >= to)
                    {
                        orderList.Add(item);
                    }
                }
            }       
            if (managerId != null)
            {
                if (orderList != null)
                {
                    foreach (var item in orderList)
                    {
                        if (item.ManagerId == managerId)
                        {
                            curList.Add(item);
                        }
                    }
                    orderList.Clear();
                    orderList = curList;
                    
                }
                else
                {
                    foreach (var item in items)
                    {
                        if (item.ManagerId == managerId)
                        {
                            orderList.Add(item);
                        }
                    }
                }
            }
            if (customerId != null)
            {
                if (orderList != null)
                {
                    foreach (var item in orderList)
                    {
                        if (item.CustomerId == customerId)
                        {
                            curList.Add(item);
                        }
                    }
                    orderList.Clear();
                    orderList = curList;
                }
                else
                {
                    foreach (var item in items)
                    {
                        if (item.CustomerId == customerId)
                        {
                            orderList.Add(item);
                        }
                    }
                }
            }
            if (productId != null)
            {
                if (orderList != null)
                {
                    foreach (var item in orderList)
                    {
                        if (item.ProductId == productId)
                        {
                            curList.Add(item);
                        }
                    }
                    orderList.Clear();
                    orderList = curList;
                }
                else
                {
                    foreach (var item in items)
                    {
                        if (item.ProductId == productId)
                        {
                            orderList.Add(item);
                        }
                    }
                }
            }
            if (orderList == null)
            {
                orderList = items;
            }
            return orderList;
        }
        public IEnumerable<Model.Manager> GetManagers()
        {
            return managerList;
        }
        public IEnumerable<Model.Product> GetProducts()
        {
            return productList;
        }
        public IEnumerable<Model.Customer> GetCustomers()
        {
            return customerList;
        }
    }
}
