using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public abstract class Car
    {
        public string Name { get; protected set; }
        public Car (string name)
        {
            this.Name = name;
        }
    }
}