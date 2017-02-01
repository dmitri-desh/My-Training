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
            this.Id = id;
            this.Pin = pin;
        }
        public override void UseKey()
        {
            throw new NotImplementedException();
        }
    }
}
