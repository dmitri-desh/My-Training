using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdersWithFilters
    {
        private static ICollection<OrderSet> orderList = new List<OrderSet>();
        private static ICollection<ManagerSet> managerList = new List<ManagerSet>();
        private static ICollection<ProductSet> productList = new List<ProductSet>();
        private static ICollection<CustomerSet> customerList = new List<CustomerSet>();
        private DateTime from;
        public DateTime From
            { get { return from; }
              set { from = orderList.Min(x => x.PurchaseDate); }
            }
        private DateTime to;
        public DateTime To
        {
            get { return to; }
            set { to = orderList.Max(x => x.PurchaseDate); }
        }
        public IEnumerable<OrderSet> GetOrders(DateTime from, DateTime to, int managerId, int customerId, int productId)
        {
            var items = new OrderRepository().GetAll().ToList();
            var curList = new List<OrderSet>();
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
        public IEnumerable<ManagerSet> GetManagers()
        {
            return managerList;
        }
        public IEnumerable<ProductSet> GetProducts()
        {
            return productList;
        }
        public IEnumerable<CustomerSet> GetCustomers()
        {
            return customerList;
        }
    }
}
