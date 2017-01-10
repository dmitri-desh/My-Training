using Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBuilder
{
    public class CustomTrainBuilder
    {
        private Train _train;
        public CustomTrainBuilder(Train train)
        {
            _train = train;
        }
        public void Build()
        {
            AddCars();
        }
        protected void AddCars()
        {
            _train.Add(new Locomotive("Паровоз", 15000));
            _train.Add(new Postal("Багажный", CarType.Freight, 200));
            _train.Add(new Passenger("Вагон №4", 36, 36, CarType.Passenger, ComfortClass.Coupe));
            _train.Add(new Passenger("Вагон №5", 52, 52, CarType.Passenger, ComfortClass.Econom));
            _train.Add(new Passenger("Вагон №6", 52, 52, CarType.Passenger, ComfortClass.Econom));
            _train.Add(new Passenger("Вагон №12", 120, 120, CarType.Passenger, ComfortClass.Obcshak));
            _train.Add(new Passenger("Вагон №7", 52, 52, CarType.Passenger, ComfortClass.Econom));
            _train.Add(new Passenger("Вагон №3", 36, 36, CarType.Passenger, ComfortClass.Coupe));
            _train.Add(new Passenger("Вагон №8", 52, 52, CarType.Passenger, ComfortClass.Econom));
            _train.Add(new Passenger("Вагон №2", 18, 18, CarType.Passenger, ComfortClass.SV));
            _train.Add(new Passenger("Вагон №9", 52, 52, CarType.Passenger, ComfortClass.Econom));
            _train.Add(new Passenger("Вагон №11", 120, 120, CarType.Passenger, ComfortClass.Obcshak));
            _train.Add(new Passenger("Вагон №10", 52, 52, CarType.Passenger, ComfortClass.Econom));
            
        }
    }
}
