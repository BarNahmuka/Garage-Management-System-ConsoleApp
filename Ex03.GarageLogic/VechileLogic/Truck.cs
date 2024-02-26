using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    class Truck : GasolineVehicle
    {
        bool m_IsTransferingHazard;
        float m_CargoSize;

        public Truck(String i_Model, String i_LicenseNumber, float i_EnergyLeft, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter, bool i_IsTransferingHazard, float i_CargoSize) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_GasolineType, i_CurrentGasInTankPerLiter, i_MaxGasInTankPerLiter)
        {
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

    }
}
