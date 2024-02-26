using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    class ElectricCar: ElectricVehicle
    {
        Car m_Car;
        public ElectricCar(String i_Model, String i_LicenseNumber, float i_EnergyLeft, float i_BatteryTimeLeftPerHours, float i_BatteryTimeMaxPerHours, eCarColor i_Color, eNumbersOfDoors i_NumbersOfDoors) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_BatteryTimeLeftPerHours, i_BatteryTimeMaxPerHours)
        {
            m_Car = new Car(i_Color, i_NumbersOfDoors);
        }

        public Car Car
        {
            get { return m_Car; }
        }
    }
}
