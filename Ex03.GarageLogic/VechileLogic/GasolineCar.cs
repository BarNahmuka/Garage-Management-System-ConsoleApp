using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    class GasolineCar: GasolineVehicle
    {
        Car m_Car;

        public GasolineCar(String i_Model, String i_LicenseNumber, float i_EnergyLeft, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter, eCarColor i_Color, eNumbersOfDoors i_NumbersOfDoors) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_GasolineType, i_CurrentGasInTankPerLiter, i_MaxGasInTankPerLiter)
        {
            m_Car = new Car(i_Color, i_NumbersOfDoors);
        }

        public Car Car
        {
            get { return m_Car; }
        }    
    }
}
