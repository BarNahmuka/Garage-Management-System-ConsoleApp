using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasolineTruck : GasolineVehicle
    {
        private Car m_car;
        bool m_IsTransferingHazard;
        float m_CargoSize;

        public GasolineTruck(String i_Model, String i_LicenseNumber, float i_EnergyLeft, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter, bool i_IsTransferingHazard, float i_CargoSize, eCarColor i_Color, eNumbersOfDoors i_NumbersOfDoors) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_GasolineType, i_CurrentGasInTankPerLiter, i_MaxGasInTankPerLiter)
        {
            m_car = new Car(i_Color, i_NumbersOfDoors);
            m_IsTransferingHazard = i_IsTransferingHazard;
            m_CargoSize = i_CargoSize;
        }

        public bool IsTransferingHazard
        {
            get { return m_IsTransferingHazard; }
        }

        public float CargoSize
        {
            get { return m_CargoSize; }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
{1},
Has hazardous substances: {2},
Cargo Size: {3}",
                base.ToString(),
                m_car.ToString(),
                m_IsTransferingHazard,
                m_CargoSize);
        }
    }
}
