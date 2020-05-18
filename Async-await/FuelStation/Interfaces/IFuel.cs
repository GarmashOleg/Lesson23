using FuelStation.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelStation.Interfaces
{
    public interface IFuel
    {
        void FillTank(int fuelLitters);
        
        FuelType FuelType { get; }

        int TankVolume { get;}
    }
}
