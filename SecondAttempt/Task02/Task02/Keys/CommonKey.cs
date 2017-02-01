using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Keys
{
    abstract class CommonKey
    {  // 4. Напишите пример класса ключа. Предусмотрите возможность его расширения до различных типов ключей (металлический ключ, магнитная карта, бесконтактный ключ).
        protected string Name;
        protected KeyType KeyType;

    public CommonKey (string name, KeyType keyType)
        {
            this.Name = name;
            this.KeyType = keyType;
        }
        public abstract void UseKey();
    }
}
