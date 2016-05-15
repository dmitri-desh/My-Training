using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomaticStation;

namespace Billing
{
    public class Report
    {
        public BillingDataBase Result { get; }
        public Report(BillingDataBase dataBase)
        {
            Result = dataBase;
        }
        public void ShowAllAccounts ()
        {
            foreach (var account in Result.Accounts)
            {
                Console.WriteLine(account.Customer.Name + " Баланс: " + account.Amount.ToString());
                ShowContracts(account);
            }
        }
        public void ShowContracts (Account account)
        {
            foreach (var contract in account.Contracts)
            {
                Console.WriteLine(contract.ContractNumber + " от " + contract.Date.ToString("dd.mm.yyyy") + " Тел.: " + contract.PhoneNumber.Value);
            }
        }
       public void ShowCallsLogFull (Account account)
        {
            Console.WriteLine("Full Report for {0}", account.Customer.Name);
            decimal sum = 0;
            foreach (var contract in account.Contracts)
            {
                var calls = from call in contract.CallsLog
                            orderby call.Started
                            select call;
                ShowCalls(calls);
                sum += calls.Sum(s => s.Amount);
            }
            Console.WriteLine("Total Amount: {0}", sum);
        }

        public void GetMonthlyReport(Account account, DateTime month)
        {
            Console.WriteLine("Monthly {1}.{2} Report for {0}", account.Customer.Name, month.Month.ToString(), month.Year.ToString());
           decimal sum = 0;
            foreach (var contract in account.Contracts)
            {
                var calls = from call in contract.CallsLog
                            where call.Started.Year == month.Year && call.Started.Month == month.Month
                            orderby call.Started
                            select call;
                ShowCalls(calls);
                sum += calls.Sum(s => s.Amount);
             }
            Console.WriteLine("Total Monthly Amount: {0}", sum);
        }
        public void GetReportBy (Account account, DateTime startDate, DateTime endDate)
        {
            Console.WriteLine("Report for {0} from {1} to {2}", account.Customer.Name, 
                                                                startDate.ToString(),
                                                                endDate.ToString()
                             );
            decimal sum = 0;
            foreach (var contract in account.Contracts)
            {
                var calls = from call in contract.CallsLog
                            where call.Started >= startDate && call.Started <= endDate
                            orderby call.Started
                            select call;
                ShowCalls(calls);
                sum += calls.Sum(s => s.Amount);
            }
            Console.WriteLine("Total Amount: {0}", sum);
        }
        public void GetReportBy(Account account, decimal amountFrom, decimal amountTo)
        {
            Console.WriteLine("Report for {0} with Amount from {1} to {2}", account.Customer.Name,
                                                                            amountFrom,
                                                                            amountTo
                             );
            decimal sum = 0;
            foreach (var contract in account.Contracts)
            {
                var calls = from call in contract.CallsLog
                            where call.Amount >= amountFrom && call.Amount <= amountTo
                            orderby call.Started
                            select call;
                ShowCalls(calls);
                sum += calls.Sum(s => s.Amount);
            }
            Console.WriteLine("Total Amount: {0}", sum);
        }
        public void GetReportBy(Account account, PhoneNumber target)
        {
            Console.WriteLine("Report for {0} with calls to number {1}", account.Customer.Name, target.Value.ToString());
            decimal sum = 0;
            foreach (var contract in account.Contracts)
            {
                var calls = from call in contract.CallsLog
                            where call.Target.Value.ToString() == target.Value.ToString()
                            orderby call.Started
                            select call;
                ShowCalls(calls);
                sum += calls.Sum(s => s.Amount);
            }
            Console.WriteLine("Total Amount: {0}", sum);
        }
        public void ShowCalls (IEnumerable<CallInfoFull> calls)
        {
            foreach (var call in calls)
            {
                Console.WriteLine("{0} {1} {2} {3}", call.Started.ToString(), call.Duration.ToString(), call.Target.Value.ToString(), call.Amount);
            }
        }
    }
}