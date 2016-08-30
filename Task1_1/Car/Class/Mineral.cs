using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class Mineral : Car, IHasCarType
    {
        public new string Name { get; protected set; }
        public double Carrying { get; protected set; }
        public CarType CarType { get; protected set; }
        public Mineral (string name, CarType carType, double carrying) : base (name)
        {
            this.Name = name;
            this.Carrying = carrying;
            this.CarType = carType;

        }
    }
}