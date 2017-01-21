using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class ObjCounter : IDisposable
    { // 2.	Напишите класс, который умеет хранить информацию об общем количестве созданных экземпляров своего типа.
        static int count = 0;
        public ObjCounter ()
        {
            count++;
            Console.WriteLine("Создан {0}-й объект", count);
        }
       
        public void Dispose()
        {
            count--;
            Console.WriteLine("Уничтожен {0}-й объект", count);
        }

        public int GetObjectsCount ()
        {
            return count;
        }
    }
}
