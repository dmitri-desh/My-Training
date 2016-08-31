using Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train("Состав пассажирский");

            CustomTrainBuilder builder = new CustomTrainBuilder(train);

            builder.Build();
            
            Console.WriteLine("Сформирован состав:");
            
            IEnumerable<Car.Car> list = train.GetCarsList();
            
            string strOutPut;
            foreach (Car.Car car in list)
            {
                strOutPut = train.GetCarInfo(car);
                Console.WriteLine(strOutPut);
            }
            
            Console.WriteLine("\n   Общая численность пассажиров: " + train.GetTotalPassengers());
            Console.WriteLine("\nОбщая численность багажных мест: " + train.GetTotalBagages());

            Console.WriteLine("\nСортиовка по уровню комфортности:\n");
            train.SortByComfortClass();
            IEnumerable<Car.Car> listSorted = train.GetSortedCars();
            foreach (Car.Car car in listSorted)
            {
                strOutPut = train.GetCarInfo(car);
                Console.WriteLine(strOutPut);
            }
            int from = 30;
            int to = 90;
            Console.WriteLine("\nВагоны, имеющие от "+from.ToString()+" до "+to.ToString()+" пассажиров:\n");

            list = train.FindCarsByPassengers(from, to);
            foreach (Car.Car car in list)
            {
                strOutPut = train.GetCarInfo(car);
                Console.WriteLine(strOutPut);
            }
        }
    }
}
