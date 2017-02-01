using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Keys
{
    class KeyContactless : CommonKey
    {
        protected string Id;
        protected int Pin;
        public KeyContactless(string name, KeyType keyType, string id, int pin) : base (name, keyType)
        {
            Id = id;
            Pin = pin;
        }
        public bool CheckPin(string id, int pin)
        {
            Console.WriteLine("Checking PIN {0}...", id);
            if (Id == id && Pin == pin) { Console.WriteLine("PIN is Ok!"); return true; }
            else { Console.WriteLine("PIN Error!"); return false; }
        }
        public override void UseKey()
        {
            Console.WriteLine("Используем {0} {1}", KeyType, Name);
        }
    }
}
