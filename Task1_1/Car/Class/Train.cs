using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    public class Train : ICollection<Car>
    {
        public string Name;
        private List<Car> _cars;
        private List<Car> _carsSorted = new List<Car>();

        public Train (string name)
        {
            this.Name = name;
            _cars = new List<Car>();
        }
        public IEnumerable<Car> GetCarsList()
        {
            return _cars.ToList();
        }
        public string GetCarInfo (Car car)
        {
            string strCarInfo = car.Name.ToString()+'\t';

            strCarInfo = strCarInfo + (car is IHasPower ? (car as IHasPower).Power.ToString() + " коней" 
                                                        : car is IHasCarType ? (car as IHasCarType).CarType == CarType.Freight ? "\tГруз. " + (car as IHasBagage).CntBagage.ToString().PadLeft(3, ' ') + " баг.мест"
                                                                                                                               : "\tПасс. " + (car as IHasBagage).CntBagage.ToString().PadLeft(3, ' ') + " баг.мест\t" + (car as IHasPassengers).CntSeats.ToString().PadLeft(3, ' ') + " пасс.мест\t" + (car as IHasComfortClass).ComfortClass.ToString()
                                                                             : "");
            
            return strCarInfo;
        }
        public IEnumerable<Car> GetPassangerCars()
        {
            return _cars.Where(t => t is IHasPassengers);
        }
        public int GetTotalPassengers()
        {
            return _cars.Where(t => t is IHasPassengers).Sum(t => (t as IHasPassengers).CntSeats);
        }
        public int GetTotalBagages()
        {
            return _cars.Where(t => t is IHasBagage).Sum(t => (t as IHasBagage).CntBagage);
        }
        public void SortByComfortClass()
        {
           _carsSorted = _cars.Where(t => t is IHasComfortClass).OrderBy(t => t is IHasComfortClass ? (t as IHasComfortClass).ComfortClass : ComfortClass.Obcshak).ToList();
        }
        public IEnumerable<Car> GetSortedCars ()
        {
            return _carsSorted.ToList();
        }
        public IEnumerable<Car> FindCarsByPassengers (int from, int to)
        {
            return _cars.Where(t => t is IHasPassengers && (t as IHasPassengers).CntSeats >= from && (t as IHasPassengers).CntSeats <= to);
        }

        public int Count
        {
            get
            {
                return _cars.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Car item)
        {
            _cars.Add(item);
        }

        public void Clear()
        {
            _cars.Clear();
        }

        public bool Contains(Car item)
        {
            return _cars.Contains(item);
        }

        public void CopyTo(Car[] array, int arrayIndex)
        {
            _cars.CopyTo(array);
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        public bool Remove(Car item)
        {
            return _cars.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}