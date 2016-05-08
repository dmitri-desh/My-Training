using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing;

namespace Builder
{
    sealed class CustomBuilder : Builder
    {
        private Account account;
        public override void Initialize()
        { }
        public override void ReadFile()
        { }
        public override void GetResult()
        { }
    }
}
