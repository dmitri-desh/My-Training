using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticStation;
using Billing;

namespace Builder
{
    sealed class CustomBuilder : Builder
    {
        private Account account;
        public override void Initialize()
        {
           var customer1    = new Customer("Иванов И.И.");
           var account1     = new Account(1, customer1);
           var billingPlan1 = new BillingPlan(BillingType.PerSecond, 50);
           var phoneNumber1 = new PhoneNumber("00-000-00-01");
           account1.Contracts.Add(new Contract("№001",
                                                      phoneNumber1,
                                                      billingPlan1
                                              )
                                  );
            account1.FillAccount(10000);

            List<IPort> ports = new List<IPort>() { new TestPort(), new TestPort() };
            List<ITerminal> terminals = new List<ITerminal>() { };

            TestStation s = new TestStation(terminals, ports);

            s.Add(new TestTerminal(new PhoneNumber("00-000-00-00")));
            s.Add(new TestTerminal(new PhoneNumber("11-111-11-11")));

            foreach (var t in terminals)
            {
                t.Plug();
            }

            //terminals[0].Call( new PhoneNumber("11-111-11-11"));
            //terminals[0].Answer();
            terminals[1].Drop();
        
        }
        public override void ReadFile()
        { }
        public override void GetResult()
        { }
    }
}
