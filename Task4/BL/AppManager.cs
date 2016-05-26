﻿using System;
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
            _watcher.Created += new FileSystemEventHandler(OnWatcherCreated); 
         }

        public void OnWatcherCreated(object sender, FileSystemEventArgs e)
        {
           // Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
         
            try
            {
                CancellationToken token = new CancellationToken();
                Action createTaskAction = () =>
                {
                    
                    using (var stream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            ParseCsv(e.Name, reader, token);
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
      
        protected void ParseCsv(string name, TextReader reader, CancellationToken token)
        {
            try
            {
                var curName = name.Substring(0, name.IndexOf('_'));
                string curRow = null;
                while ((curRow = reader.ReadLine()) != null && !token.IsCancellationRequested)
                {
                    var columns = curRow.Split(',').ToList();
                    for (int i = 0; i < columns.Count(); i++)
                    {
                        Console.Write("{0} ", columns[i]);
                    }
                    // Parse string
                    // add records to data context

                    // add Order
                  //  Console.WriteLine();
                }

                if (curRow != null && token.IsCancellationRequested)
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