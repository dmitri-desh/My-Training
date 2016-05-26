using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class AppManager : IDisposable
    {
        private FileSystemWatcher _watcher;
        private BlockingCollection<CancellationToken> cancelTokenCollection = new BlockingCollection<CancellationToken>();
        public AppManager(FileSystemWatcher watcher)
        {
            _watcher = watcher;
            _watcher.Created += this.OnWatcherCreated;
        }

        public void OnWatcherCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                CancellationToken token = new CancellationToken();

                Action createTaskAction = () =>
                {
                    using (var stream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            ParseCsv(reader, token);
                        }
                    }
                };

                var task = new Task(createTaskAction, token);
                cancelTokenCollection.Add(token);

                task.ContinueWith((sourceTask) =>
                {
                    cancelTokenCollection.Take(token);
                });

                task.Start();

            }
            finally
            {
                // Sql Server 2008 R2
            }
        }
        protected void ParseCsv(TextReader reader, CancellationToken token)
        {

            try
            {
                string current = null;
                while ((current = reader.ReadLine()) != null && !token.IsCancellationRequested)
                {
                    // Parse string
                    // add records to data context

                    // add Order


                }

                if (current != null && token.IsCancellationRequested)
                {
                    // Rollback
                }
            }
            catch (IOException e)
            {
                //Rollback
            }


        }
        private object orderSyncObj = new object();

        public void Add(Order order)
        {
            // create repository
            lock (orderSyncObj)
            {

            }
        }
        public void Run()
        {
            if (_watcher != null && !_watcher.EnableRaisingEvents)
            {
                _watcher.EnableRaisingEvents = true;
            }
        }
        public void Stop()
        {
            if (_watcher != null && _watcher.EnableRaisingEvents)
            {
                _watcher.EnableRaisingEvents = false;
            }
        }
        public void Dispose()
        {
            if (_watcher != null)
            {
                Stop();
                _watcher.Dispose();
                _watcher = null;
            }
        }
        ~AppManager()
        {
            Dispose();
        }
    }
}
