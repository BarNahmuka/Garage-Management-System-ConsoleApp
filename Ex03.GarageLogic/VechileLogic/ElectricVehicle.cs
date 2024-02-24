using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        float m_BatteryTimeLeftPerHours;
        float m_BatteryTimeMaxPerHours;

        public ElectricVehicle(String i_Model, String i_LicenseNumber, float i_EnergyLeft, float i_BatteryTimeLeftPerHours, float i_BatteryTimeMaxPerHours) : base(i_Model, i_LicenseNumber, i_EnergyLeft)
        {
            m_BatteryTimeLeftPerHours = i_BatteryTimeLeftPerHours;
            m_BatteryTimeMaxPerHours = i_BatteryTimeMaxPerHours;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if(i_HoursToCharge + m_BatteryTimeLeftPerHours <= m_BatteryTimeMaxPerHours)
            {
                m_BatteryTimeLeftPerHours = i_HoursToCharge + m_BatteryTimeLeftPerHours;
                m_EnergyLeft = (m_BatteryTimeLeftPerHours / m_BatteryTimeLeftPerHours) * 100;
            }
        }

        public float BatteryTimeLeftPerHours
        {
            get { return m_BatteryTimeLeftPerHours; }
        }

        public float BatteryTimeMaxPerHours
        {
            get { return m_BatteryTimeMaxPerHours; }
        }

    }
}
