using FuelStation.Interfaces;
using FuelStation.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelStation.Classes
{
    public class Car : IFuel, IMoving
    {
        private const int lowSpending = 10;
        private const int upSpending = 20;

        private int _tankState;

        public event EventHandler<string> CarState;

        public Car(string carIdentifier, FuelType fuelType, int tankVolume)
        {
            CarIdentifier = carIdentifier;
            FuelType = fuelType;
            TankVolume = tankVolume;
            _tankState = tankVolume;
            IsTankEmpty = false;
        }

        public int TankState {
            private set
            {
                if (value > 0)
                {
                    _tankState = value;
                }
            }
            get => _tankState;
        }

        public string CarIdentifier {get;}

        //public int TankState { private set; get; }

        public FuelType FuelType { get; }

        public bool IsTankEmpty { get; private set; }

        public int TankVolume { get; }

        public void FillTank(int fuelLitters)
        {
            TankState += fuelLitters;
            CarState?.Invoke(null, $"Car {CarIdentifier} is full!");
            IsTankEmpty = false;
        }

        public void Move()
        {
            CarState?.Invoke(null, $"Car {CarIdentifier} started moving");

            while (_tankState > upSpending)
            {
                var rand = new Random().Next(lowSpending, upSpending);
                TankState -= rand;
                CarState?.Invoke(null, $"Car {CarIdentifier} continues moving with tank {TankState}");
            }

            IsTankEmpty = true;
            TankState = 0;
            CarState?.Invoke(null, $"****Car {CarIdentifier} is going to the fuel station!****");

        }
    }
}
