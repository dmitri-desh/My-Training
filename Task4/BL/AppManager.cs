using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class AppManager : IDisposable
    {
        private FileSystemWatcher _watcher;
        private BlockingCollection<CancellationToken> cancelTokenCollection = new BlockingCollection<CancellationToken>();
      //  private IList<string> customersUniq = new List<string>();
     //   private IList<string> productsUniq = new List<string>();
     //   private IList<Order> orders = new List<Order>();
        public AppManager(FileSystemWatcher watcher)
        {
            _watcher = watcher;
            _watcher.Created += new FileSystemEventHandler(OnWatcherCreated); 
         }

        public void OnWatcherCreated(object sender, FileSystemEventArgs e)
        {
           Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
         
            try
            {
                CancellationToken token = new CancellationToken();
                Action createTaskAction = () =>
                {
                    
                    using (var stream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            ParseCsv(e.Name, reader, token);
                           
                        }
                    }
                };

                var task = new Task(createTaskAction, token);
                cancelTokenCollection.Add(token);

                task.ContinueWith((sourceTask) =>
                {
                    cancelTokenCollection.Take(token);
                });

                task.Start();

            }
            finally
            {
                // Sql Server 2008 R2
               
            }
        }
      
        protected void ParseCsv(string name, TextReader reader, CancellationToken token)
        {
            try
            {
                var curName = name.Substring(0, name.IndexOf('_'));
                string curRow = null;
              //  var customers = new List<string>();
              //  var products = new List<string>();
                IFormatProvider culture = new System.Globalization.CultureInfo("ru-RU", true);
                DateTime dateVal;
                while ((curRow = reader.ReadLine()) != null && !token.IsCancellationRequested)
                {
                    var columns = curRow.Split(',').ToList();
                    if (columns[0].Substring(1,1) == ".")
                    {
                        columns[0] = "0" + columns[0];
                    }
                    dateVal = DateTime.ParseExact(columns[0], columns[0].Substring(4,1) == "-" ? "yyyy-MM-dd HH:mm:ss" : "dd.MM.yyyy HH:mm:ss", culture);
                    //    customers.Add(columns[1]);
                    //   products.Add(columns[2]);
                    //   orders.Add(new Order(dateVal, curName, columns[1], columns[2], columns[3]));
                    
                    AddToDAL(new Order(dateVal, curName, columns[1], columns[2], columns[3]));
/*
                    for (int i = 0; i < columns.Count(); i++)
                    {
                        Console.Write("{0}|", columns[i]);
                    }
                    // Parse string
                    // add records to data context

                    // add Order
                    Console.WriteLine();
                    */
                }
              
            /*    foreach (var customer in customers.Distinct())
                {
                    customersUniq.Add(customer);
                 //   Console.Write("{0}|", customer);
                }
               // Console.WriteLine();
              
                foreach (var product in products.Distinct())
                {
                    productsUniq.Add(product);
                  // Console.Write("{0}|", product);
                }
                Console.WriteLine();
              */  
                if (curRow != null && token.IsCancellationRequested)
                {
                    // Rollback
                    Dispose();
                }
            }
            catch (IOException e)
            {
                //Rollback
                Dispose();
            }


        }
        private object orderSyncObj = new object();

        public void AddToDAL(Order order)
        {
            // create repository
            lock (orderSyncObj)
            {
               var customerFactory = new DAL.ContextFactory();
                customerFactory.ContextObject.CustomerSet.Add(new Model.Customer()
                {
                    SecondName = order.CustomerName
                });
                customerFactory.ContextObject.SaveChanges();
                // var customerRepository = new DAL.CustomerRepository<DTO, Entity, Context>(customerFactory);
                // customerRepository.AddContext();
            }
            
            lock (orderSyncObj)
            {
                var productFactory = new DAL.ContextFactory();
                productFactory.ContextObject.ProductSet.Add(new Model.Product()
                {
                    Name = order.ProductName
                });
                productFactory.ContextObject.SaveChanges();
            }

            lock (orderSyncObj)
            {
                var productFactory = new DAL.ContextFactory();
                productFactory.ContextObject.ProductSet.Add(new Model.Product()
                {
                    Name = order.ProductName
                });
                productFactory.ContextObject.SaveChanges();
            }
            lock (orderSyncObj)
            {
                var managerFactory = new DAL.ContextFactory();
                managerFactory.ContextObject.ManagerSet.Add(new Model.Manager()
                {
                    SecondName = order.ManagerName
                });
                managerFactory.ContextObject.SaveChanges();
            }
            lock (orderSyncObj)
            {
                var orderFactory = new DAL.ContextFactory();
                orderFactory.ContextObject.OrderSet.Add(new Model.Order()
                {
                    PurchaseDate = order.PurchaseDate,
                    Amount = order.Amount,
                    Manager = new Model.Manager(order.ManagerName),
                    Customer = new Model.Customer(order.CustomerName),
                    Product = new Model.Product(order.ProductName)
                });
                orderFactory.ContextObject.SaveChanges();
            }
        }
        public void Run()
        {
            if (_watcher != null && !_watcher.EnableRaisingEvents)
            {
                _watcher.EnableRaisingEvents = true;
            }
        }
        public void Stop()
        {
            if (_watcher != null && _watcher.EnableRaisingEvents)
            {
                _watcher.Created -= OnWatcherCreated;
                _watcher.EnableRaisingEvents = false;
              
            }
        }
        public void Dispose()
        {
            if (_watcher != null)
            {
                Stop();
                _watcher.Dispose();
                _watcher = null;
            }
        }
        ~AppManager()
        {
            Dispose();
        }
    }
}
