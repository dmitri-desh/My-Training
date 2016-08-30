using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class Postal : Car, IHasBagage, IHasCarType
    {
        public new string Name { get; protected set; }
        public int CntBagage { get; protected set; }
        public CarType CarType { get; protected set; }
        public Postal (string name, CarType carType ,int cntBagage) : base (name)
        {
            this.Name = name;
            this.CarType = carType;
            this.CntBagage = cntBagage;
        }
    }
}