using FuelStation.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuelStation.Classes
{
    public class Engine
    {
        private IList<Car> cars;
        private IList<FuelStation> stations;

        public Engine()
        {
            cars = new List<Car>()
            {
                new Car("Car1", FuelType.Petrol, 50),
                new Car("Car2", FuelType.Gas, 70),
                new Car("Car3", FuelType.Gas, 40)
            };

            stations = new List<FuelStation>()
            {
                new FuelStation("Station1", FuelType.Gas, 500),
                new FuelStation("Station2", FuelType.Petrol, 500),
                new FuelStation("Station3", FuelType.Gas, 500)
            };
        }

        public void Run()
        {
            var carTasks = new List<Task>();

            foreach (var car in cars)
            {
                carTasks.Add(new Task(() => ProcessingCar(car)));
            }

            foreach (var carTask in carTasks)
            {
                carTask.Start();
            }

            carTasks.ForEach(task => task.Wait());
        }

        private void ProcessingCar(Car car)
        {
            car.CarState += Printnotification;
            while (!car.IsTankEmpty)
            {
                car.Move();
            }

            var station = FindStation(car.FuelType);
            //station.FuelStationState += Printnotification;
            station.Refuel(car, car, Printnotification);

            car.CarState -= Printnotification;
            //station.FuelStationState -= Printnotification;
        }

        public void Printnotification(object sender, string message)
        {
            Console.WriteLine(message);
        }

        private FuelStation FindStation(FuelType fuelType)
        {
            var randomStation = stations[new Random().Next(0, stations.Count)];

            while (randomStation.FuelType != fuelType)
            {
                randomStation = stations[new Random().Next(0, stations.Count)];
            }

            return randomStation;
        }
    }
}
