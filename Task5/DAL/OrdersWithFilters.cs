using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdersWithFilters
    {
        private static ICollection<Model.OrderSet> orderList = new List<Model.OrderSet>();
        private static ICollection<Model.ManagerSet> managerList = new List<Model.ManagerSet>();
        private static ICollection<Model.ProductSet> productList = new List<Model.ProductSet>();
        private static ICollection<Model.CustomerSet> customerList = new List<Model.CustomerSet>();
        public IEnumerable<Model.OrderSet> GetOrders(DateTime from, DateTime to, double managerId, double customerId, double productId)
        {
            var items = new OrderRepository().GetAll().ToList();
            var curList = new List<Model.OrderSet>();
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
        public IEnumerable<Model.ManagerSet> GetManagers()
        {
            return managerList;
        }
        public IEnumerable<Model.ProductSet> GetProducts()
        {
            return productList;
        }
        public IEnumerable<Model.CustomerSet> GetCustomers()
        {
            return customerList;
        }
    }
}
