using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Keys
{
    class KeyMetal : CommonKey
    {
        public KeyMetal(string name, KeyType keyType) : base(name, keyType)
        {

        }
        public override void UseKey()
        {
            Console.WriteLine("Используем {0} {1}", KeyType, Name);
        }
    }
}
