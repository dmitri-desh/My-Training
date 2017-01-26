using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Keys
{
    class CommonKey
    {  // 4. Напишите пример класса ключа. Предусмотрите возможность его расширения до различных типов ключей (металлический ключ, магнитная карта, бесконтактный ключ).
        public string Name { get; set; }
        public KeyType KeyType { get; set; }

    public CommonKey (string name, KeyType keyType)
        {
            this.Name = name;
            this.KeyType = keyType;
        }
    }
}
