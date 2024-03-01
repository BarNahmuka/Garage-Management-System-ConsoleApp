using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class GasolineVehicle : Vehicle
    {
        eFuel m_GasolineType;
        float m_CurrentGasInTankPerLiter;
        float m_MaxGasInTankPerLiter;

        public GasolineVehicle(String i_Model, String i_LicenseNumber, float i_EnergyLeft, List<Wheel> i_Wheels, eFuel i_GasolineType, float i_CurrentGasInTankPerLiter, float i_MaxGasInTankPerLiter) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_Wheels)
        {
            m_GasolineType = i_GasolineType;
            m_CurrentGasInTankPerLiter = i_CurrentGasInTankPerLiter;
            m_MaxGasInTankPerLiter = i_MaxGasInTankPerLiter;
        }

        public void RefuelTank(float i_LitersToFuel , eFuel i_FuelType)
        {
            if ((m_CurrentGasInTankPerLiter + i_LitersToFuel <= m_MaxGasInTankPerLiter))
            {
                if (i_FuelType == m_GasolineType)
                {
                    m_CurrentGasInTankPerLiter = m_CurrentGasInTankPerLiter + i_LitersToFuel;
                    m_EnergyLeft = (m_CurrentGasInTankPerLiter / m_MaxGasInTankPerLiter) * 100;
                }
                else
                {
                    throw new ArgumentException("Full type selcted not fitting to the vehicle");
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxGasInTankPerLiter - m_CurrentGasInTankPerLiter);
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

        public override string ToString()
        {
            return string.Format(
                @"{0}
Gasoline type: {1}
Current Gasoline amount: {2}
Max Gasoline amount: {3}",
                base.ToString(),
                m_GasolineType,
                m_CurrentGasInTankPerLiter,
                m_MaxGasInTankPerLiter
                );
        }
    }
}
