using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public partial class Service : ServiceBase
    {
        private BL.AppManager appManager;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var watchPath = System.Configuration.ConfigurationManager.AppSettings["DirectoryWatching"];
            appManager = new BL.AppManager(new System.IO.FileSystemWatcher(watchPath, "*.csv"));
            appManager.Run();
        }

        protected override void OnStop()
        {
            try
            {
                appManager.Stop();
            }
            finally
            {
                appManager.Dispose();
            }
        }
    }
}
