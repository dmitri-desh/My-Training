using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Keys
{
    class KeyMagnetic : CommonKey
    {
        protected string Id;
        public KeyMagnetic (string name, KeyType keyType, string id) : base (name, keyType)
        {
            Id = id;
            
        }
        public bool CheckLogin (string id)
        {
            Console.WriteLine("Checking login {0}...", id);
            if (Id == id) { Console.WriteLine("Login successful!"); return true; }
                                                       else { Console.WriteLine("Login failed!");     return false; }
         }
        public override void UseKey()
        {
            Console.WriteLine("Используем {0} {1}", KeyType, Name);
        }
    }
}
