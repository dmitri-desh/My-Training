using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class ObjCounter : IDisposable
    { // 2.	Напишите класс, который умеет хранить информацию об общем количестве созданных экземпляров своего типа.
        static int count = 0;
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public ObjCounter ()
        {
            count++;
            Console.WriteLine("Создан {0}-й объект", count);
        }
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("Object disposed...");
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        public int GetObjectsCount ()
        {
            return count;
        }
    }
}
