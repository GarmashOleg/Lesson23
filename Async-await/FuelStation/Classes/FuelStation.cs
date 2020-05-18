using FuelStation.Interfaces;
using FuelStation.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelStation.Classes
{
    public class FuelStation
    {
        private readonly object locker = new object();

        public event EventHandler<string> FuelStationState;

        public FuelStation(string carIdentifier, FuelType fuelType, int volume)
        {
            FuelIdentifier = carIdentifier;
            FuelType = fuelType;
            Volume = volume;
        }

        public string FuelIdentifier { get; }

        public int Volume { private set; get; }

        public FuelType FuelType { get; }

        public void Refuel(IFuel fuelableObject, Car car, EventHandler<string> handler)
        {
            lock (locker)
            {
                FuelStationState += handler;
                //car.CarState += handler;

                if (FuelType == fuelableObject.FuelType && Volume >= fuelableObject.TankVolume)
                {
                    FuelStationState?.Invoke(null, $"Station {FuelIdentifier} is refuling.... {car.CarIdentifier}");
                    Volume -= fuelableObject.TankVolume;
                    Console.WriteLine($"{FuelIdentifier} has on stock {Volume}");
                    //FuelStationState = null; 
                    //return;
                }

                
                else
                {
                    FuelStationState?.Invoke(null, $"Station {FuelIdentifier} does not have enough fuel");
                    //FuelStationState -= handler;
                }

                //car.CarState -= handler;
                FuelStationState -= handler;
            }
        }
    }
}
