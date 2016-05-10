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
        public void ShowContracts (Account account )
        {
            foreach (var contract in account.Contracts)
            {
                Console.WriteLine(contract.ContractNumber + " от " + contract.Date.ToString("dd.mm.yyyy") + " Тел.: " + contract.PhoneNumber.Value);
            }
        }
        //ToDo
        public void GetMonthlyReport(DateTime month)
        { }
        public void GetReportBy (DateTime date)
        { }
        public void GetReportBy(decimal amount)
        { }
        public void GetReportBy(PhoneNumber target)
        { }
    }
}