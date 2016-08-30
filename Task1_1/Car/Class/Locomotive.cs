using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class Locomotive : Car, IHasPower
    {
        public new string Name { get; protected set; }
        public double Power { get; protected set; }
        public Locomotive (string name, double power) : base(name)
        {
            this.Name = name;
            this.Power = power;

        }
    }
}