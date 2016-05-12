using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticStation;
using Billing;
using System.Configuration;

namespace Builder
{
    sealed class CustomBuilder : Builder
    {
        private BillingDataBase dataBase;
        private TestStation station;
        private List<IPort> ports;
        private List<ITerminal> terminals;

        public DateTime start;
        public DateTime now;
        public TimeSpan span;
       
        public void AccelerateTime(int times) // emulate the acceleration time "times" times
        {
            if (start != null)
            {
                span = DateTime.Now.Subtract(start);
                now = start.AddSeconds(span.TotalSeconds * times);
                Console.WriteLine("Now: {0}", now.ToString());
            }
        }
        public override void Initialize()
        {
           dataBase = new BillingDataBase();

           ports = new List<IPort>() { new TestPort(), new TestPort() };
           terminals = new List<ITerminal>() { };
           station = new TestStation(terminals, ports);

           #region Customer 1  
           var customer    = new Customer("Иванов И.И.");
           var account     = new Account(1, customer);
           var billingPlan1 = new BillingPlan(BillingType.PerSecond, 50);
           var phoneNumber1 = new PhoneNumber("00-000-00-00");
           account.Contracts.Add(new Contract("№000",
                                                      phoneNumber1,
                                                      billingPlan1
                                              )
                                  );

            var billingPlan2 = new BillingPlan(BillingType.PerMinute, 300);
            var phoneNumber2 = new PhoneNumber("11-111-11-11");
            account.Contracts.Add(new Contract("№111",
                                                       phoneNumber2,
                                                       billingPlan2
                                               )
                                   );
            account.FillAccount(10000);
            station.Add(new TestTerminal(phoneNumber1));
            station.Add(new TestTerminal(phoneNumber2));
            dataBase.Accounts.Add(account);
            #endregion

           #region Customer 2
            customer = new Customer("Петров П.П.");
            account = new Account(2, customer);
            billingPlan1 = new BillingPlan(BillingType.PerSecond, 30);
            phoneNumber1 = new PhoneNumber("22-222-22-22");
            account.Contracts.Add(new Contract("№222",
                                                       phoneNumber1,
                                                       billingPlan1
                                               )
                                   );
            billingPlan2 = new BillingPlan(BillingType.PerMinute, 320);
            phoneNumber2 = new PhoneNumber("33-333-33-33");
            account.Contracts.Add(new Contract("№333",
                                                       phoneNumber2,
                                                       billingPlan2
                                               )
                                   );
            account.FillAccount(15000);
            station.Add(new TestTerminal(phoneNumber1));
            station.Add(new TestTerminal(phoneNumber2));
            dataBase.Accounts.Add(account);
            #endregion
            
           #region Customer 3
            customer = new Customer("Сидоров С.С.");
            account = new Account(3, customer);
            billingPlan1 = new BillingPlan(BillingType.PerSecond, 30);
            phoneNumber1 = new PhoneNumber("44-444-44-44");
            account.Contracts.Add(new Contract("№444",
                                                       phoneNumber1,
                                                       billingPlan1
                                               )
                                   );
            account.FillAccount(16000);
            station.Add(new TestTerminal(phoneNumber1));
            dataBase.Accounts.Add(account);
            #endregion

           #region Customer 4
            customer = new Customer("Васин В.В.");
            account = new Account(4, customer);
            billingPlan1 = new BillingPlan(BillingType.PerMinute, 330);
            phoneNumber1 = new PhoneNumber("55-555-55-55");
            account.Contracts.Add(new Contract("№555",
                                                       phoneNumber1,
                                                       billingPlan1
                                               )
                                   );
            account.FillAccount(20000);
            station.Add(new TestTerminal(phoneNumber1));
            dataBase.Accounts.Add(account);
            #endregion

        }
       
        public override void Emulate()
        {
            int times;
            Int32.TryParse(ConfigurationManager.AppSettings["times"], out times);


            foreach (var t in terminals)
            {
                t.Plug();
            }

            start = DateTime.Now;
            Console.WriteLine("Start: {0}", start.ToString());

            terminals[0].Call(new PhoneNumber("11-111-11-11"));
            AccelerateTime(times);
            terminals[0].Answer();
            AccelerateTime(times);
            terminals[1].Drop();
            AccelerateTime(times);
        }
        public override void GetResult()
        {
           Report result = new Report(dataBase);
            result.ShowAllAccounts();
        }
    }
}
