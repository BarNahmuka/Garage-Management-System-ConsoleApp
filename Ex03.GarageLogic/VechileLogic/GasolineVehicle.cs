using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    public abstract class GasolineVehicle : Vehicle
    {
        eFuel m_GasolineType;
        float m_CurrentGasInTankPerLiter;
        float m_MaxGasInTankPerLiter;

        public GasolineVehicle(String i_Model, String i_LicenseNumber, float i_EnergyLeft, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter) : base(i_Model, i_LicenseNumber, i_EnergyLeft)
        {
            m_GasolineType = i_GasolineType;
            m_CurrentGasInTankPerLiter = i_CurrentGasInTankPerLiter;
            m_MaxGasInTankPerLiter = i_MaxGasInTankPerLiter;
        }

        public void RefuelTank(float i_LitersToFuel , eFuel i_FuelType)
        {
            if((m_CurrentGasInTankPerLiter + i_LitersToFuel <= m_MaxGasInTankPerLiter) && i_FuelType == m_GasolineType)
            {
                m_CurrentGasInTankPerLiter = m_CurrentGasInTankPerLiter + i_LitersToFuel;
            }
        }

        public eFuel GasolineType
        {
            get { return m_GasolineType; }
        }

        public float CurrentGasInTankPerLiter
        {
            get { return m_CurrentGasInTankPerLiter; }
        }

        public float MaxGasInTankPerLiter
        {
            get { return m_MaxGasInTankPerLiter; }
        }
    }
}
