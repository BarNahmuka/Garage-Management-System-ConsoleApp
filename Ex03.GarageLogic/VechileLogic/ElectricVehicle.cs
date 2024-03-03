using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeftPerHours;
        private readonly float r_BatteryTimeMaxPerHours;
        public ElectricVehicle(String i_Model, String i_LicenseNumber, float i_EnergyLeft, List<Wheel> i_Wheels, float i_BatteryTimeLeftPerHours, float i_BatteryTimeMaxPerHours) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_Wheels)
        {
            m_BatteryTimeLeftPerHours = i_BatteryTimeLeftPerHours;
            r_BatteryTimeMaxPerHours = i_BatteryTimeMaxPerHours;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if (i_HoursToCharge + m_BatteryTimeLeftPerHours <= r_BatteryTimeMaxPerHours)
            {
                m_BatteryTimeLeftPerHours = i_HoursToCharge + m_BatteryTimeLeftPerHours;
                m_EnergyLeft = (m_BatteryTimeLeftPerHours / r_BatteryTimeMaxPerHours) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_BatteryTimeMaxPerHours - m_BatteryTimeLeftPerHours);
            }
        }

        public float BatteryTimeLeftPerHours
        {
            get { return m_BatteryTimeLeftPerHours; }
        }

        public float BatteryTimeMaxPerHours
        {
            get { return r_BatteryTimeMaxPerHours; }
        }
        public override string ToString()
        {
            return string.Format(@"{0}
Current battery time left: {1}
Max battery time: {2}",
                base.ToString(),
                m_BatteryTimeLeftPerHours,
                r_BatteryTimeMaxPerHours);
        }
    }
}
