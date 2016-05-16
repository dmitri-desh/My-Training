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
       
       
        public override void Initialize()
        {
           dataBase = new BillingDataBase();
            
            ports = new List<IPort>() { new TestPort(), new TestPort(), new TestPort(), new TestPort() };
            terminals = new List<ITerminal>() { };
            station = new TestStation(terminals, ports);

            station.CallInfoPrepared += Station_CallInfoPrepared;

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
            terminals.Add(new TestTerminal(phoneNumber1));
            
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
            terminals.Add(new TestTerminal(phoneNumber1));
            dataBase.Accounts.Add(account);
               #endregion

             

        }

        private void Station_CallInfoPrepared(object sender, CallInfo e)
        {
            dataBase.Accounts.FirstOrDefault().Contracts.SingleOrDefault(x => x.PhoneNumber.Value.ToString() == e.Source.Value.ToString()).AddCallToLog(e);
           // throw new NotImplementedException();
        }

        public override void Emulate()
        {
           


            foreach (var t in terminals)
            {
                t.Plug();
                Console.WriteLine("Plug terminal {0}", t.Number.Value.ToString());
            }
           
            Console.WriteLine();
            start = DateTime.Now;
            Console.WriteLine("Start: {0}", start.ToString());

            terminals[0].Call(new PhoneNumber("11-111-11-11"));
            terminals[0].Answer();
            terminals[1].Drop();

          
            terminals[0].Call(new PhoneNumber("11-111-11-11"));
            terminals[0].Answer();
            terminals[1].Drop();


        }
        public override void GetResult()
        {
           Report result = new Report(dataBase);
           
            result.ShowAllAccounts();
            result.ShowCallsLogFull(dataBase.Accounts.SingleOrDefault(x => x.Customer.Name == "Иванов И.И."));
            result.GetMonthlyReport(dataBase.Accounts.SingleOrDefault(x => x.Customer.Name == "Иванов И.И."), new DateTime(2016, 5, 1));
            result.GetReportBy(dataBase.Accounts.SingleOrDefault(x => x.Customer.Name == "Петров П.П."), new DateTime(2016, 5, 16, 17, 0, 0), new DateTime(2016, 5, 16, 17, 20, 30));
            result.GetReportBy(dataBase.Accounts.SingleOrDefault(x => x.Customer.Name == "Иванов И.И."), 5000, 10000);
            result.GetReportBy(dataBase.Accounts.SingleOrDefault(x => x.Customer.Name == "Петров П.П."), new PhoneNumber("11-111-11-11"));
         
        }
    }
}
