using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class Passenger : Car, IHasBagage, IHasPassengers, IHasCarType, IHasComfortClass
    {
        public new string Name { get; protected set; }
        public int CntSeats { get; protected set; }
        public int CntBagage { get; protected set; }
        public CarType CarType { get; protected set; }
        public ComfortClass ComfortClass { get; protected set; }
        public Passenger ( string name, int cntSeats, int cntBagage, CarType carType, ComfortClass comfortClass) : base (name)
        {
            this.Name = name;
            this.CntSeats = cntSeats;
            this.CntBagage = cntBagage;
            this.CarType = carType;
            this.ComfortClass = comfortClass;
        }
    }
}