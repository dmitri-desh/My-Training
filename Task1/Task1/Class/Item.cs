using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public Item (string name)
        {
            this.Name = name;
        }
    }
}