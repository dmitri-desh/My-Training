using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomaticStation;

namespace Billing
{
    public class Report
    {
        public Account Result { get; }
        public Report(Account account)
        {
            Result = account;
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