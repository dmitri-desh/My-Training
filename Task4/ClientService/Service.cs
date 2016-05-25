using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service
{
    public partial class Service : ServiceBase
    {
        private EventLog eventLog = new EventLog();
        public Service()
        {
            InitializeComponent();
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog.Source = "MySource";
            eventLog.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("In OnStart");
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("In onStop.");
        }
        protected override void OnContinue()
        {
            eventLog.WriteEntry("In OnContinue.");
        }
    }
}
