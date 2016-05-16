using AutomaticStation;
using Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefLibrary
{
    public class CallInfoLog
    {
        private CallInfo CallInfo { get; set; }
      
        public void AddInfoToRefLibrary (object sender, CallInfo callInfo)
        {
            this.CallInfo = callInfo;
        }
    }
}
